   M S B A M L   `   `   `  ���� H  DWaveGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:BinauralBeatsBinauralBeats      BinauralBeats.MainWindow   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    +localclr-namespace:BinauralBeats    -     � Title$  
MainWindow��$	��400��$	��525��$	��350��$	��450�� � SizeToContent$ Manual=� � 	Resources +  %BinauralBeats.DoubleToLogIntConverter   
Double2Int  ButtonTextStyle �� 
TargetType �� Property �� Value��%X   &	        &	        �� " d�.���  � ��$
 10pt(���  � ��$ Caliri)�.���  � ShowGridLines .   � RowDefinitions �� $��4* ��� $��1* ��� $��1* ��� $��1* ��� $
��Auto � � ColumnDefinitions �� $��2* ��� $��* �.+��� -   $��waveGraphCanvas��$��0��
���   �$��2��.+�� -   $��
waveGraph1��	 � Points	 �    ������ 
 �� EndPoint$
 1,0.5&� �� 
StartPoint$ 0,0.5&�.���  � Color$ 	#FF00FF77�� � Offset$ 0Q�� $ 	#FF26FF00��$ 1Q�� -   $��
waveGraph2��	 �    ������ $
 1,0.5&�$ 0,0.5&�.��� $ 	#FFFC9B88��$ 0Q�� $ 	#FFFFC338��$ 1Q���  �� Left$ 0��
 �� Top$ 0��.+��� -   $��waveTip��Current Wave:���� $
 1,0.5&�$ 0,0.5&�.��� $ 	#FF00FF77��$ 0Q�� $ 	#FF26FF00��$ 1Q��� $��LeftToRight=� �� Orientation$ 
Horizontal=�$��1��$��2��$��Center=�$��Center=�.+��� $��LeftToRight=�$ 
Horizontal=�$��Center=�$��Center=�.+��� -   $��
playButton��$��Center=�$��3q�$��36��$��40��.��� 
���   � � Points �   ����� @T� $��Center=�$��Center=��� -   $��
stopButton��$��Center=�$��3q�$��36��$��40��.���� 
���   �$��15��$��15��$��5q�$��Center=�$��Center=��� $��1��$��1��$��LeftToRight=�$ 
Horizontal=�$��Center=�$��Right=�.+��� $��Center=�	Volume:�� -   $��amplitudeSlider��$	��100��$��Center=�$��Right=� � Minimum$ 0Q� � Maximum$	 100Q� � Value$ 50Q� � SmallChange$ 1Q�$��5q�� $��LeftToRight=� � Orientation$ 
Horizontal=�$��2��$��2��$��Center=�$��Center=�.+��� $ 
Horizontal=�.+��� $��Center=�20Hz�� -	   $��frequencySlider��$	��200��$��Center=�$ 1.30103Q�$ 4.30103Q�$ 3Q�$ 0.0001Q� � LargeChange$ 0.001Q� �� TickPlacement$
 None=�$	��0,5q��� $��Center=�	20000Hz�� -
   $��frequencyInputTextBox��$��5,5,0,5q� �� TextAlignment$ Right=�$��50��$��1,1,0,1q� � DataContext ��  �� ElementName$ frequencySlider�� � ToolTip ��  �� RelativeSource �� *Self+ �� Path$) #(Validation.Errors)[0].ErrorContent�.������ $ Value� �� Mode$ TwoWay=�  �� 	Converter#  [  ! �� UpdateSourceTrigger$! PropertyChanged=�" �� ValidationRules" &   BinauralBeats.frequencyRangeRule  
#   min$# 20��
$   max$$ 20000��.���� $��Center=�Hz� $��3��$��2��$��Center=�$��Center=�.+�d� -   $��sineWaveButton��$��5q�% d� 	IsChecked$% FalseY�#��[ {��� $ 
playButton��$ OneWay=�$ 	IsEnabled�.��	Sine Waved� -   $��triangleWaveButton��$��5q�#��[ {��� $ 
playButton��$ OneWay=�$ 	IsEnabled�.��Triangle Waved� -   $��rectangleWaveButton��$��5q�#��[ {��� $ 
playButton��$ OneWay=�$ 	IsEnabled�.��Rectangle Waved� -   $��pinkNoiseButton��$��5q�#��[ {��� $ 
playButton��$ OneWay=�$ 	IsEnabled�.��
Pink Noise�� $��1��$��3��$��Right=�.+��� -   $��
helpButton��$��40��$��40��$��32(�$��Broadway)�$��Normal"�$��0q�$��Normal$�$��Normal&�& � Cursor$
& Help��{�. $��3q�.��?9� -   $ ��sweepFrequencyModeExpander��$��0��$��4��$��2��' 9� ExpandDirection$' Right=�$��Sweep Frequency Mode��$��Center=�.���� $��0��$��4��$
��Left=�$��Center=�$ 
Horizontal=�.+��� -   $ ��sweepFrequencyModeCheckBox��$��Center=��� $
��10,0q�$��3���� -   $��minSweepFrequencyTextBox��$��40��$��5,0,3,0q�$��20��{��� $ 
playButton��$ OneWay=�$ 	IsEnabled��� $��Center=�Hz ~�� -   $��maxSweepFrequencyTextBox��$��40��$��5,0,3,0q�$��20000��{��� $ 
playButton��$ OneWay=�$ 	IsEnabled��� $��Center=�Hz�� $
��10,0q�$��3���� $��Center=�Speed�� -   $��sweepFrequencySpeedSlider��$	��100��$ 10Q�$	 180Q�$ 1Q�$ 30Q�$	 100Q�