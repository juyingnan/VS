   M S B A M L   `   `   `  ����  OnlineShopLiteDemoClient)    #OnlineShopLiteDemoClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
MainWindow��5   	   $	��200��6   $	��525��6)   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5	      $��* �6   �� 5
      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� $��0��6   Customer ID6.   �� 5   
   $��1��6   Credit Card No61   �� 5   
   $��2��6   Toaster Type6/   �� 5   
   $��3��6   
Quantity6+   �� 5   
   $��4��6   Cancel if Delay62   �� 5   
   -   5        $��CUSTOMER_ID_TEXTBOX��5   /   $��1��6   $��0��6"   .��6J   C777776R   �� 5   
   -   5        $��CRESIT_CARD_NO_TEXTBOX��5   /   $��1��6   $��1��6"   .��6M   A123456U   �� 5   
   -   5        $��TOASTER_TYPE_COMBOBOX��5   0   $��1��6   $��2��6#    �� SelectedIndex$ 0��6M   .@�5      �� $��A��6   �� 5      $��B��6   �� 5      $��C��6   5       �� 5!   
   -   5        $��QUANTITY_TEXTBOX��5!   /   $��1��6   $��3��6"   .��6G   16J   �� 5"   
   -   5        $��ISCANCEL_CHECKBOX��5"   0   $��1��6   $��4��6#   6K   �� 5$   
   -   5        $��RESULT_TEXTBOX��5$   C   $��0��6   $��5��6"   $��2��6/   .��6Y   " Order result will be shown here.6{   �� 5%   
   -   5        $��0��5%      $��6��6!   $��2��6.   $	��200��6B   .��6e   Order6l   5&      5'      