# SE Button Writer "PCM Chip Writer"

音声再生物理ボタンに音声を書き込む。

複数音声がある場合ランダムで再生される。ランダムの確率は設定できる。

## 対応ハードウェア

- [KE-SB01(p1901_sebutton_A_farmware)](https://github.com/kamibushiele/p1901_sebutton_A_farmware)

## 必要なもの

- 本プログラムを動作させるwindowsPC
- SE Button 本体
- USBケーブル
- 音声ファイル(*.wav, *.mp3)

## 使用方法

1. 音声ファイルの読み込み
   1. 書き込みたいファイルを読み込ませる
   2. 必要に応じてweight(重み)も設定する
2. 本体電源をONにする
3. USBケーブルでPCと本体を接続する
4. "Serial Ports"の選択
   1. 「reload」をクリック
   2. 「USB-SERIAL CH340」を選択(出ない場合ドライバをインストールする)
5. **本体の再生ボタンを押す**
6. 「Flush」をクリック

## weight(重み)設定

読み込んだ音声ファイルをダブルクリックするとweight(重み)が設定できる。

ボタンを押したときに再生される音声は、重み付き確率で選択される。

**ただしweightが0の音声が1つでもあると他のweightに関係なくい常に読み込んだ順番に再生される。**

weightがそれぞれW,音声の数がN個の場合、n番目の音声が選択される確率は

<img src="https://latex.codecogs.com/svg.image?\frac{W_n}{W_0+W_1+\cdots+W_{N-1}}" alt = "\frac{W_n}{W_0+W_1+\cdots+W_{N-1}}"/>

となる。例えば全ての音声のweight Wが同じ場合(ただし0以外)確率は1/Nとなる。

## ライセンスLicense

本ソフトウェアはMITライセンス下で[公開](https://github.com/kamibushiele/p1901_sebutton_C_writer)されています。`LICENSE.txt`を確認してください

利用しているライブラリとライセンスは`Licenses/`を確認してください
