   M S B A M L   `   `   `  ����  
CarViewApp     CarViewApp.AddNewCarDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  AddNewCarDialog��5   	   $	��234��6!   $	��529��6.    � 
ResizeMode$ NoResize=�6;    � WindowStartupLocation$ CenterScreen=�6Q   .��5      �  � RowDefinitions 5   
   �� 5      $	��144 �6   �� 5      $��51 �6    � 	Resources 5   
      
CarsXmlDoc � Source��%6   &	        � 5      $ Inventory.xml?�61   6J   5      .+�5   
   �� -   5        $��lstCars��5      $��0��6"   ��5      ��  �� Source# [   �� XPath$ /Inventory/Car�� �� View 5      �� 5      .P�5      �� 	 �� Width$		 100��6%   $��ID��61   
 �� DisplayMemberBinding
 6=   �� $ @carID���� 5      $		 100��6%   $
��Make��61   
 6?   �� $
 Make���� 5      $		 100��6%   $��Color��61   
 6@   �� $ Color���� 5      $		 100��6%   $��Pet Name��61   
 6C   �� $ PetName��5      5      � 5   
   $��1��6   .+�5      �� $0��*Select a row to add to your car collection��6   $��10q�6I   �� 5      -   5        $��btnOK��5      $��OK��6"   $��80��6/   $��25��6:   $��10q�5        �� 	IsDefault . $��1��62   6?   �� 5!      -   5        $��	btnCancel��5!      $��Cancel��6&   $��80��67   $��25��6B   $��10q�5"       . $��2��62   6?   5#      5$      5%      