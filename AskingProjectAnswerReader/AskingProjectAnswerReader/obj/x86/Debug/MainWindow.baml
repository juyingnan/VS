   M S B A M L   `   `   `  ����  AskingProjectAnswerReader*    $AskingProjectAnswerReader.MainWindow   5   	   \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   8x,http://schemas.microsoft.com/winfx/2006/xaml    5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��700��6)    � 	Resources 5         answerXmlDoc��%   &	        � 5   
   6   5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5        $��	answerLst��5      $��1��6$    � DataContext# [  61    �� SelectionMode$ Extended=�5   p    J� 	AllowDrop .  ��6   ��  �� Source# [   �� XPath$ /ArrayOfQuestion/Question�� �� View 5      �� 5      .P�5      �� 	 �� Width$	 30��6%   $��ID��60   
 �� DisplayMemberBinding
 6<   �� $ ID���� 5      $		 200��6%   $��Question��61   
 6C   �� $ questionBody���� 5      $		 300��6%   $��Choices��61   
 6B   �� $ 	allChoice���� 5      $	 70��6%   $��Answer��60   
 6@   �� $ answer��5      5!      ]� 5$   
   $��0��6   .+�5%      o� -   5        $��mainMenu��5%      .@�5&      m� $
��File��6   .@�5'      m� -   5        $��menuItemFileOpen��5'   -   $
��Open��6   6E   �� 5(      m� 5)      -   5        $��menuItemFileExit��5)   -   $
��Exit��6   6E   5*      m� 5+      $
��Edit��6   .@�5,      m� -   5        $��menuItemEditCopy��5,   -   $
��Copy��6   6E   �� 5-      6"   m� 5.      -   5        $��menuItemCopyID��5.   +   $��ID��6    m� IsCheckable .  m� 	IsChecked . 6T   m� 5/      -   5        $��menuItemCopyQstBD��5/   5   $��QuestionBody��6    .  . 6a   m� 50      -   5        $��menuItemCopyAllChoice��50   2   $��	AllChoice��6    .  . 6b   m� 51      -	   5        $��menuItemCopyAnswer��51   B   $��Answer��6    .  . 6\   52      53      54      56      57      