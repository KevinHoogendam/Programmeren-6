   M S B A M L   `   `   `  ����@  <Ninja, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Ninja.View
Ninja.View  5   	   1clr-namespace:Ninja.ConverterNinja.Converter  5   	        Ninja.View.ViewNinjaWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Ninja.View     5   	   -conclr-namespace:Ninja.Converter     5   	     � Title$  ViewNinjaWindow��5	   	   $	��500��6!   $	��500��6.    � DataContext 5
   	   �� *	NinjaList+   Locator �� Source# [   � 	Resources 5      )  #Ninja.Converter.GoldToEuroConverter  goldToEuroConverter��%   &	         5   
   6"   5      .��5      �� $��12q�6   ._�5   
   �� .+�5      �  � ColumnDefinitions 5      �� 5      $	��150 �6'   �� 5      $	��150 �6'   �� 5      $��* �6'   �� 5      $	��100 �6'   .+�5      �� $��28(�6@   $��0��6N   ��6   �� *SelectedNinja.Name+6N   �� 5      $��28(�6@   $��1��6N   ��6   �� *SelectedNinja.Gold+6N   �� 5      $	��100��6   $��50��6%   $��28(�61   $
��Shop��6?   
�������$
��Bold"�5   ,   ���	#FF44AE3F$��3��5      ��6*   �� *ShowShopCommand+5      5       &   System.Windows.Controls.DataGrid  5"         AutoGenerateColumns .     
IsReadOnly . $��0,6,0,0q�6�   ���	#FF979494   GridLinesVisibility$ 
Horizontal=�6�      HorizontalGridLinesBrush �	#FFF0E0E0	   HeadersVisibility$	 Column=�6
  
 �� SelectedItem
 6E   �� *SelectedGear+ �� Mode$ TwoWay=���6x   �� *
NinjasGear+   Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6%      
Foreground �	#FF1D16161  +System.Windows.Controls.DataGridBoundColumn   Binding 60   �� *Id+6G     5%      $
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6L    63   �� *Name+6L     5&      $ 	GoldValue��6%   $ * 6V    68   �� *	GoldValue+6V   5(      �� 5)      $	��100��6   $��50��6!   $��18(�6-   $
��Sell��6;   
�������$
��Bold"�5*   ,   
���  ��$��0��5+      ��6*   �� *SellGearCommand+5,      �� 5-      $��	Strength:��6   $��18(�6)   $��0��67   $��0��6G   �� 5.      $��18(�67   $��2��6E   $��0��6U   ��6   �� *TotalStrength+6U   �� 5/      $��Agility:��6   $��18(�6(   $��0��66   $��1��6F   �� 50      $��18(�66   $��2��6D   $��1��6T   ��6   �� *TotalAgility+6T   �� 51      $��Intelligence:��6   $��18(�6-   $��0��6;   $��2��6K   �� 52      $��18(�6;   $��2��6I   $��2��6Y   ��6   �� *TotalIntelligence+6Y   �� 53      $��Your Gold in Euro:��6   $��18(�62   $��0��6@   $��3��6P   �� 54      $��18(�6m   $��2��6{   $��3��6�   ��6   �� *SelectedNinja.Gold+ �� 	Converter# [ 6�   55      56      57      