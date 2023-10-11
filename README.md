# FillMeIn.NET

## 概要

FillMeInはPDFフォームを埋めるため、またフォームフィールドの値を取得するためのコマンドラインユーティリティです。このユーティリティは、英語と日本語の文字を扱えます。

## 必要条件

- .NET SDK
- 日本語テキスト用のTTFフォント（`japanese.ttf`）

## コンパイル

x86向けに依存関係なしの単一の実行可能ファイルをコンパイルするには：

```bash
dotnet publish -c Release -r win-x86 --self-contained true /p:PublishSingleFile=true
```

### フォント

実行可能ファイルと同じフォルダに`japanese.ttf`という名前のファイルを配置してください。これは日本語テキスト用に使用されます。このリポジトリにはNoto Sans Japaneseというサンプルフォントが含まれており、任意の`.ttf`フォントによって`japanese.ttf`ファイルを上書きできます。

## 使い方

### PDFフォームを埋める

```bash
.\FillMeIn.exe fill <pdfPath> <outputPdfPath> <csvString|csvFilePath>
```

- `pdfPath`: 入力PDFファイルへのパス。
- `outputPdfPath`: 埋められたPDFが保存されるパス。
- `csvString|csvFilePath`: フィールド値を含むCSV文字列またはCSVファイルへのパス。

### CSVとしてフォームフィールドを取得

```bash
.\FillMeIn.exe get <pdfPath> [outputPath]
```

- `pdfPath`: 入力PDFファイルへのパス。
- `outputPath`（オプション）: CSV出力が保存されるパス。指定しない場合は、出力はコンソールに表示されます。

## 例

PDFフォームを埋めるには：

```bash
.\FillMeIn.exe fill input.pdf output.pdf "Name,John\nAge,30"
```

または、CSVファイルを使用して：

```bash
.\FillMeIn.exe fill input.pdf output.pdf fields.csv
```

フォームフィールドを取得するには：

```bash
.\FillMeIn.exe get input.pdf
```

または、それらをCSVファイルに保存するには：

```bash
.\FillMeIn.exe get input.pdf output.csv
```