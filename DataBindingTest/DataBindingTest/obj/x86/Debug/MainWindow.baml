   M S B A M L   `   `   `  ����J  FDataBindingTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DataBindingTestDataBindingTest  5   	        DataBindingTest.MainWindow   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	   -localclr-namespace:DataBindingTest    5   	     � Title$  
MainWindow��5   	   $	��300��6   $	��300��6)    � 	Resources 5        DataBindingTest.People 
  Family  DataBindingTest.Person   Name
   Age.  (DataBindingTest.AgeToForegroundConverter  ageConverter �� DataType �� Path �� 	Converter��%�  &	        &	 �     (�� �     5      *, +)7    5   
     5	      $	 Tom��6   $ 11��6&     5
      $
 John��6   $ 12��6'     5      $ Melissa��6   $ 38��6*   5        5   
   6)   �� 5   
   "  6   .R�5      �� �� 5      ��6    �� $
 Name�	 (age: �� 5      ��6&   �� $	 Age���6@   �� $	 Age�8   )5      5      5      .��5      � -   5        $��mainGrid��5       � DataContext# [  6    � RowDefinitions 5   
   �� 5      $
��1.5* �6   6,   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $
��2.5* �6   6,   	 � ColumnDefinitions	 5   
   �� 5      $��* �6   6+   �� 5      $��3* �6   6,   .+�5"   
   �� $��1��6   $��0��6"   $
 �� IsSynchronizedWithCurrentItem$

 TrueY�6G    �� SelectedValuePath$	 Age��5#      ��5"   /   ��  �� 
GroupStyle 5$      �� 5%       �� Member$ GroupStyle.Default��6   5'      �� 5)   
   $��0��6   $��1��6$   $��Center=�61   $��5q�6L   Name:6^   �� 5*   
   -   5        $��nameTextBox��5*   0   $��1��6   $��1��6#   $��Center=�6C   $��5q�6^   ��5+      �� $
 Name�.��6.   5,      �� 5-   
   $��0��6   $��2��6$   $��Center=�61   $��5q�6L   Age:6]   �� 5.   
   -   5        $��
ageTextBox��5.   /   $��1��6   $��2��6"   $��Center=�6A   $��5q�6\   ��5/      �� $	 Age�# [  � ToolTip 50      ��  �� RelativeSource �� *Self+$) #(Validation.Errors)[0].ErrorContent�.��6t   ��51      �� 52      $	 Age�6    �� UpdateSourceTrigger$ PropertyChanged=�6%    �� ValidationRules 53      %  DataBindingTest.NumberRangeRule  54      
   min$ 0��60   
   max$	 128��68   56      .��57      58      A� 59   
   $��1��6   $��3��6&   .+�5:      �� -   5        $��birthdayButton��5:      $��Center=�6+   $��5q�6c   ��5;      �� $ 
Foreground� �� ElementName$ 
ageTextBox��.��6P   
Birthday6Z   �� 5<      -   5        $��
backButton��5<      $��Center=�6'   $��5q�6[   .��6f   <6l   �� 5=      -   5        $��fowardButton��5=      $��Center=�6)   $��5q�6`   $��>��6k   6y   d� 5>      -   5        $��	addButton��5>      $��Center=�6,   $��5q�6`   .��6k   Add6p   d� 5?      -   5        $��
sortButton��5?      $��Center=�6-   $��5q�6b   .��6m   Sort6s   d� 5@      -	   5        $��filterButton��5@      $��Center=�6/   $��5q�6f   .��6q   Filter6y   d� 5A      -
   5        $��groupButton��5A      $��Center=�6.   $��5q�6d   .��6o   Group6v   5B      5C      5D      