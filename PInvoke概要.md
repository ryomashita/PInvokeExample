# P/Invoke で構造体を渡す方法

## References

- https://tech.blog.aerie.jp/entry/2015/08/13/155225

## 用語の説明

### C#

- 値型: 
  - 値型の変数には、その型のインスタンスが直接格納される。
  - 数値型, char, bool, enum, 構造体, タプル, ...
- 参照型: 
  - 参照型の変数には、そのインスタンスへの参照が格納される。
  - クラス, 配列, 文字列, record, インターフェイス, ...
- マネージドコード (Managed Code): 
  - ".NET 系のランタイム上で実行を「管理される」コード。"
    - ランタイムは自動メモリ管理、型安全性、セキュリティ境界などを提供する。
  - C#, VB.NET, F# など .NET 上で実行できる言語で書かれたコードのこと。
  - ["マネージド コード" とは (Microsoft Learn)](https://learn.microsoft.com/ja-jp/dotnet/standard/managed-code)
- アンマネージドコード (Unmanaged Code): 
  - "マネージドでない、.NET ランタイムが管理しないコード。"
  - C, C++ など .NET 以外の言語で書かれたコードのこと。
- P/Invoke (Platform Invoke):
  - アンマネージドライブラリ内の構造体、コールバック、関数を、マネージドコードから呼び出すための技術。
  - [プラットフォーム呼び出し (P/Invoke) (Microsoft Learn)](https://learn.microsoft.com/ja-jp/dotnet/standard/native-interop/pinvoke)
- マーシャリング (Marshalling) : 
  - マネージドコードとアンマネージドコードの間で型を変換するため、型を構成するデータをコピー・変換すること。
  - Blittable 型の場合、マーシャリングは不要。
- Blittable: 
  - マネージド型とアンマネージド型の間で、マーシャリング無しにデータを転送できる型。
    - Blittable な型 = 数値型, 数値ポインタ (IntPtr, UIntPtr), Blittable 型の固定長一次元配列、書式指定された構造体
    - 非 Blittable な型の例 = bool, char, string, object, ...
  - Marshalling が不要なため、高速にデータを転送できる。

## DLL 探索パスの解決

https://learn.microsoft.com/ja-jp/dotnet/standard/native-interop/native-library-loading

## 関連クラス

### `StructLayoutAttribute`

マネージドメモリ内の class, struct の物理レイアウトを制御するための attribute。

#### `LayoutKind`

メンバーがどのようにレイアウトされるかを指定する。

```csharp
// Sequential: 宣言された順序で配置する。
// オフセットは `Pack` と併せて確定する。
[StructLayout(LayoutKind.Sequential)]
public struct Point
{
   public int x;
   public int y;
}

// Explicit: 各メンバーのオフセットを `FieldOffset` で指定する。
[StructLayout(LayoutKind.Explicit)]
public struct Rect
{
   [FieldOffset(0)] public int left;
   [FieldOffset(4)] public int top;
   [FieldOffset(8)] public int right;
   [FieldOffset(12)] public int bottom;
}

// Auto (default): ランタイムが最適な配置方法を選択する。
// アンマネージドに公開不可。
[StructLayout(LayoutKind.Auto)]
```

- `CharSet`: 文字列のエンコーディングを指定する。
  - `LPWSTR`: Unicode 文字列
  - `LPSTR`: ANSI 文字列
- `Pack`: フィールドのアライメントを指定する。
  - 0 または 2 のべき乗で指定する。 (1 ~ 128)
  - 0: デフォルトのアライメントを使用する。
  - 1~128: 型のサイズまたは指定された値でアライメントする。
- `Size`: 構造体の最小サイズを指定する。
  - ※ 指定できるのは最小サイズだけで、実際のサイズを完全に制御するわけではない。

## サンプル

- シンプルな例
- アンマネージドコードに関数 (delegate) を渡す。
  - https://learn.microsoft.com/ja-jp/dotnet/standard/native-interop/pinvoke#invoking-managed-code-from-unmanaged-code
- 構造体を渡す
- 様々な型のマーシャリング
  - https://learn.microsoft.com/ja-jp/dotnet/standard/native-interop/customize-struct-marshalling
    - bool
    - 配列
    - 文字列
    - union
  - https://learn.microsoft.com/ja-jp/dotnet/standard/native-interop/type-marshalling
    - 組み込み型の既定のマーシャリング規則

