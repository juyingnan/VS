   M S B A M L   `   `   `  ����   BinauralBeatsNavigation*    $BinauralBeatsNavigation.Page3_PlayUI   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -     N� Title$  Page4_PlayUI��$	��480��$	��320�� N� 	KeepAlive .  � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType �� RadiusX �� RadiusY	 � Cursor
 � Color � Offset �� Triggers P� Property P� Value �� 
TargetName O� 	GlowColor O� GlowSize   buttonTextStyle  DarkBrushSlider �� 
StartPoint �� EndPoint  NormalBrush  
LightBrush  NormalBorderBrushSlider  PressedBorderBrush  DisabledBorderBrush �� Color  DisabledForegroundBrush  DisabledBackgroundBrush 	 SliderThumbStyle 
 SliderButtonStyle  HorizontalSlider � RowDefinitions �� CornerRadius ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton��%�  '��       &	  _    &	 
    &	 e    &	 �    &	     &	 r    &	 �    &	 �    &	 �    &		 �    7  7  7  7  &	
 �    &	 X    7  7  7 
 7 	 7 
 '�� L    7  �� " ��.���  � �� �� " ��.R�� .+��� $
��rect��$��60��$��60��
�������$��5��$ 10��$ 10��$��5q�$
	 Hand����
� .��� $
 Black��$ 0Q�� $
 	#FF242424��$ 1Q��� #��z�� P�  �@J�IsMouseOver . . ��� $
 rect�� �@J�BitmapEffect O� $ 	#FFB200FF��$ 10Q���  � ��$ 20q��� .���  � ��$
 20pt(���  � ��
 �������  � ��
 ���� ��  �@��TextAlignment$ Center=���  �@�Cursor$
 Hand����  � �� .  �� $	 0,0&�$	 0,1&���� � $

 #FFF��$	 0.0Q�� $
 	#FF0492FF��$	 1.0Q��� $	 0,0&�$	 0,1&���� � $

 #FFF��$	 0.0Q�� $

 #CCC��$	 1.0Q��� $	 0,0&�$	 0,1&���� � $

 #FFF��$	 0.0Q�� $
 	#FF3D3D3D��$	 1.0Q��� $	 0,0&�$	 0,1&���� � $
 	#FF858585��$	 0.0Q�� $
 Black��$	 1.0Q��� $	 0,0&�$	 0,1&���� � $

 #444��$	 0.0Q�� $

 #888��$	 1.0Q��� $
 #AAA���� $
 #888���� $
 #EEE���� " n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$ 30����  � ��$ 30����  � �� �� " n�.R�A� $��Ellipse��8��  8�� $��3�� P�  �@J�IsMouseOver . . ��� $ Ellipse��8   � ���� $ Ellipse�� �@J�BitmapEffect O� $ 	#FFB200FF��$ 5Q�P�  � {� .  . ��� $ Ellipse��8   � ���� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � ��$ 40����  � �� �� " ��.R��� 
������ �� " ��.R��  �� $
��Auto �#��z��.+��� $��TrackBackground��$��0q�$ 4��$��15��8��  8�� $��3q�]� $��
PART_Track��$��1�� �� 8�� $��Slider.DecreaseLarge�� n� 8��  �� 8�� $��Slider.IncreaseLarge���� " ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$ 60����  � ��$ 20����  � ��8   .���� ���� $ 0.5,1&�$ 0.5,0&�.��� $
 Black��$ 1Q�� $
 Black��$ 0Q�� $
 	SlateGray��$ 0.484Q�.+��� $��50�� �� TextAlignment$ Center=�$
��Bold"�$��Calibri)�$��40(�
�������Binaural Beats�� $��30��$ Right=�$
��Bold"�$��Calibri)�$��24(�
������� �� Padding$ 0,0,20,0q�$��0,0,0,10q�	Enjoy it!� .+��� $	��300��$	��200��
���   �$��10�� �� StrokeLineJoin$ Round=� �� StrokeStartLineCap$ Round=���
� .��� $
 	#FF80FF95��$ 0.902Q�� $
 White��$ 1Q��� -   $��waveGraphCanvas��$	��280��$	��180��$��Center=�$��Center=�.+�� -   $��leftWaveGraphLine�� � Points �   �J] v��J]$��3��$ Round=�$ Round=� �� StrokeEndLineCap$ Round=����� $ 1,0.5&�$ 0,0.5&�.��� $
 	#FF007900��$ 0Q�� $

 Lime��$ 1Q�� -   $��rightWaveGraphLine�� �   �J] v��J]$��3��$ Round=�$ Round=�$ Round=����� $ 1,0.5&�$ 0,0.5&�.��� $
 	#FF005E79��$ 0Q�� $
 	#FF00DAFF��$ 1Q��   � ColumnDefinitions  �� �� �� �� .+��� -   $��
playButton��$��1��$��Right=�.��� ! � Points! �   @x}��� ���$��4��$��Center=�$��Center=�
�������$ Round=�$ Round=�$��5,0,0,0q�$
	 Hand������ $ 1,0.5&�$ 0,0.5&�.��� $

 Lime��$ 0Q�� $
 	#FF009500��$ 1Q��� $��2��$
��Left=�.��� !! �   @x}@x}@x}@x}$��4��$��Center=�$��Center=�
�������$ Round=�$ Round=�$
	 Hand������ $ 1,0.5&�$ 0,0.5&�.��� $	
 Red��$ 0Q�� $
 	#FF950000��$ 1Q��� -   $��
backButton������ .R�� $��	backArrow��" � FillRule$" Nonzero=�$��5��G! �    -1��������� ������ ��������������� Zb$��
10,20,0,15q�
�������$ Round=�$
	 Hand������ $ 1,0.5&�$ 0,0.5&�.��� $
 	#FF00FF2F��$ 0Q�� $
 	#FF009500��$ 1Q� P�  �@J�IsMouseOver . . ���  �@J�BitmapEffect O� $ AntiqueWhite��$ 10Q�.���� #��[  BACK�� $��3��$��Calibri)�$��14(�$ Center=�$��	0,15,10,0q�
�������Volume�� -   $��amplitudeSlider��$��2��$��30��$��Right=�$��5,15,5,0q�$��Center=�$��80��# � Maximum$	# 100Q�$ � SmallChange$$ 1Q�% � LargeChange$% 20Q�& � Value$& 33Q�$��2���   �� �� .+��� $��Calibri)�$
��Bold"�$��64(�$ Center=�
�������$��0��$��2��	-- : --