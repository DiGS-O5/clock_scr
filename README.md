# Flip Clock Screensaver

3Dフリップアニメーションで時間と日付を表示するWindows用スクリーンセーバーです。
A Windows screensaver that displays time and date using a 3D flip animation.

---

## Features / 機能

* フリップ式デジタル時計（時・分）
  Flip-style digital clock (hour & minute)

* 日付表示（フリップ対応）
  Date display with flip animation

* 3Dアニメーション（WPF + Media3D）
  3D rendering using WPF (Media3D)

* マウスドラッグによるカメラ操作
  Camera control via mouse drag

* 設定画面あり
  Configurable settings UI

* スクリーンセーバー（.scr）対応
  Works as a Windows screensaver (.scr)

---

## Usage / 使用方法

### インストール / Installation

1. Release から `Flip_Clock.scr` をダウンロード
   Download `Flip_Clock.scr` from Releases

2. 任意の場所に配置
   Place it anywhere

3. 右クリック → 「インストール」
   Right-click → Install

または / Or:

```text
C:\Windows\System32
```

に配置してスクリーンセーバーとして選択
Place it in the directory above and select it as a screensaver

---

### 設定 / Settings

設定画面から以下を変更可能：
You can configure:

* 表示のON/OFF / Display toggles
* カラー / Colors
* フォント / Fonts
* マウスカーソル非表示 / Hide cursor
* 終了条件 / Exit conditions
* カメラ角度 / Camera angle

---

### カメラ操作 / Camera Control

* マウスドラッグで角度変更
  Drag mouse to rotate camera

* 「Save Angle」で保存
  Save angle using "Save Angle"

* 「Reset Angle」で初期化
  Reset angle using "Reset Angle"

---

## Build / ビルド

### 必要環境 / Requirements

* Windows
* Visual Studio 2022 or later
* .NET (depending on project configuration)

---

### ビルド手順 / Build

```bash
msbuild clock_scr.sln /p:Configuration=Release
```

または Visual Studio からビルド
Or build using Visual Studio

---

### スクリーンセーバー化 / Screensaver Conversion

```text
clock_scr.exe → Flip_Clock.scr
```

にリネームすることでスクリーンセーバーとして動作
Rename to `.scr` to use as a screensaver

---

## Release / リリース

GitHub Actions により以下が自動実行されます：
Handled automatically by GitHub Actions:

* ビルド / Build
* publish
* `.scr` 生成 / Generate `.scr`
* zip化 / Package into zip
* Release作成 / Create release

---

## License

This project is licensed under a custom non-commercial license.

### Summary

* Personal use: Allowed
* Modification: Allowed
* Redistribution: Allowed (must include license and copyright)
* Commercial use: **Prohibited**

Attribution is required.

---

### 日本語

本ソフトウェアは非商用利用に限り、使用・改変・再配布が可能です。

以下の条件を守ってください：

* 著作権表示および本ライセンスを必ず含めること
* 商用利用は禁止

---

## Disclaimer

This software is provided "as is", without warranty of any kind.

---

## Author

DiGS-O5
