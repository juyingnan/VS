   M S B A M L   `   `   `  ����H  DWaveGenerator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WaveGeneratorWaveGenerator  5   	       WaveGenerator.MainWindow   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   +localclr-namespace:WaveGenerator    5   	   -   5          � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   $	��300��6N   $	��450��6^    � 	Resources 5      +  %WaveGenerator.DoubleToLogIntConverter   
Double2Int  ButtonTextStyle �� 
TargetType �� Property �� Value��%�   &	        &	        5   
   6(   �� 5
   
   " d�6(   .�5      ��  � ��$
 11pt(�6)   �� 5       � ��$ Caliri)�6+   5      5      .��5      �  � ShowGridLines .   � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   �� -   5        $��waveGraphCanvas��5   1   $��0��6   
���   �$��2��6H   .+�5      � -   5        $��	waveGraph��5       � Points �    ����5      �� 5       	 �� EndPoint$	 1,0.5&�6*   
 �� 
StartPoint$
 0,0.5&�6;   .��5!      �  � Color$ 	#FF00FF77��6+    � Offset$ 0Q�6=   � 5"      $ 	#FF26FF00��6'   $ 1Q�69   5#      5%      �� 5&       �� Left$ 0��6   
 �� Top$ 0��6)   .+�5'      �� -   5        $��waveTip��5'      Current Wave:��5(      �� 5)      $	 1,0.5&�6.   $
 0,0.5&�6?   .��5*      � $ 	#FF00FF77��6+   $ 0Q�6=   � 5+      $ 	#FF26FF00��6'   $ 1Q�69   5,      5.      5/      50      �� 53   
   $��LeftToRight=�6    �� Orientation$ 
Horizontal=�61   $��1��6J   $��2��6X   $��Center=�6l   $��Center=�6�   .+�54      �� $��LeftToRight=�6   $ 
Horizontal=�65   $��Center=�6N   $��Center=�6i   .+�55      �� -   5        $��
playButton��55      $��Center=�6D   $��3q�6_   $��36��6j   $��40��6v   .��56      � 
���   � � Points �   ����� @T� $��Center=�6>   $��Center=�6Y   6x   57      �� 58      -   5        $��
stopButton��58      $��Center=�6@   $��3q�6[   $��36��6f   $��40��6r   .��59      �� 
���   �$��15��6)   $��15��65   $��5q�6@   $��Center=�6K   $��Center=�6f   6�   5:      5;      5<      �� 5>   
   $��2��6   $��1��6%   $��LeftToRight=�62   $ 
Horizontal=�6N   $��Center=�6g   $��Right=�6�   .+�5?      �� $��Center=�6   	Volume:5A      �� 5B      -   5        $��amplitudeSlider��5B      $	��100��6,   $��Center=�68   $��Right=�6S    � Minimum$ 0Q�6o    � Maximum$	 100Q�6{    � Value$ 50Q�6�    � SmallChange$ 1Q�6�   $��5q�6�   6�   5C      � 5F   
   $��LeftToRight=�6    � Orientation$ 
Horizontal=�60   $��2��6I   $��2��6V   $��Center=�6j   $��Center=�6�   .+�5G      �� $ 
Horizontal=�6   .+�5H      �� $��Center=�6   20Hz6=   �� 5I      -   5        $��frequencySlider��5I      $	��200��60   $��Center=�6<   $ 1.30103Q�6W   $ 4.30103Q�6i   $ 3Q�6{   $ 0.0001Q�6�    � LargeChange$ 0.001Q�6�    �� TickPlacement$
 None=�6�   $	��0,5q�6�   �� 5J      $��Center=�6   	20000Hz6@   �� 5K      -	   5        $��frequencyInputTextBox��5K   A   $��5,5,0,5q�6    �� TextAlignment$ Right=�6+   $��50��5L   I   $��1,1,0,1q�5M   |    � DataContext 5L      ��  �� ElementName$ frequencySlider�� � ToolTip 5M      ��  �� RelativeSource �� *Self+ �� Path$) #(Validation.Errors)[0].ErrorContent�.��6�   ��5N      �� 5O      $ Value�6"    �� Mode$ TwoWay=�6/    �� 	Converter# [  6=     �� UpdateSourceTrigger$  PropertyChanged=�6e   ! �� ValidationRules! 5P      &   WaveGenerator.frequencyRangeRule  5Q   "   
"   min$" 20��6;   
#   max$# 20000��6D   5S      .��5T   $   5U      �� 5V      $��Center=�6   Hz6;   5W      5Y      � 5[   
   $��3��6   $��2��6!   $��Center=�65   $��Center=�6P   .+�5\      d� -
   5        $��sineWaveButton��5\   &   $��5q�6   $ d� 	IsChecked$$ FalseY�6Y   #��[ 6�   {�6k   �� $ 
playButton��$ OneWay=�$ 	IsEnabled�.��6�   	Sine Wave6�   d� 5]      -   5        $��triangleWaveButton��5]   &   $��5q�6   #��[ 6�   {�6a   �� $ 
playButton��$ OneWay=�$ 	IsEnabled�.��6�   Triangle Wave6�   d� 5^      -   5        $��rectangleWaveButton��5^   &   $��5q�6   #��[ 6�   {�6c   �� $ 
playButton��$ OneWay=�$ 	IsEnabled�.��6�   Rectangle Wave6�   d� 5_      -   5        $��pinkNoiseButton��5_   &   $��5q�6   #��[ 6�   {�6[   �� $ 
playButton��$ OneWay=�$ 	IsEnabled�.��6�   
Pink Noise6�   5`      �� 5b   
   $��1��6   $��3��6%   $��Right=�62   .+�5c      �� -   5        $��
helpButton��5c      $��40��6'   $��40��63   $��32(�6>   $��Broadway)�6L   $��Normal"�6b   $��0q�6v   $��Normal$�6�   $��Normal&�6�   % � Cursor$
% Help��6�   {�. .��6�   ?5e      5f      5g      5h      