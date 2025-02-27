# P/Invoke で構造体を渡す方法

## References

- https://tech.blog.aerie.jp/entry/2015/08/13/155225

## 用語の説明

### C#

- 値型: 値型の変数には、その型のインスタンスが直接格納される。
  - 数値型, char, bool, enum, 構造体, タプル, ...
- 参照型: 参照型の変数には、そのインスタンスへの参照が格納される。
  - クラス, 配列, 文字列, record, インターフェイス, ...
- マネージドコード (Managed Code): .NET 系のランタイム上で実行を「管理される」コード。
  - C#, VB.NET, F# など .NET 上で実行できる言語で書かれたコードを指す。
  - ランタイムは自動メモリ管理、型安全性、セキュリティ境界などを提供する。
  - ["マネージド コード" とは (Microsoft Learn)](https://learn.microsoft.com/ja-jp/dotnet/standard/managed-code)
- アンマネージドコード (Unmanaged Code): マネージドでない、.NET ランタイムが管理しないコード。
  - C, C++ など .NET 以外の言語で書かれたコードを指す。
- P/Invoke (Platform Invoke):
  - アンマネージドライブラリ内の構造体、コールバック、関数を、マネージドコードから呼び出すための技術。
  - [プラットフォーム呼び出し (P/Invoke) (Microsoft Learn)](https://learn.microsoft.com/ja-jp/dotnet/standard/native-interop/pinvoke)
- マーシャリング: マネージドコードとアンマネージドコードの間で型を変換するプロセス。
  - `bool` を何バイトで表現するか、配列のサイズ、文字列のエンコーディングなどを、マネージドコード上で明示する必要がある。

## ネイティブライブラリの読み込み

https://learn.microsoft.com/ja-jp/dotnet/standard/native-interop/native-library-loading


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

