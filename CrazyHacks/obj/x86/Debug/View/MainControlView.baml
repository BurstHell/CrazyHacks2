   M S B A M L   `   `   `  ����E  ACrazyHacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CrazyHacks.ViewCrazyHacks.View  5      ;"clr-namespace:CrazyHacks.ViewModelCrazyHacks.ViewModel  5      %    CrazyHacks.View.MainControlView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:CrazyHacks.View     5      8	viewModel"clr-namespace:CrazyHacks.ViewModel     5        � DataContext  5	      ��  �� Path$ MainControl�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��5 �6   �� 5      $��2* �6   .+�5   
   ]� $��0��6   .+�5      �� $	��Top=�6    �� Orientation$ 
Horizontal=�6/   $��Right=�6H   .+�5      �� .��6   Host6!   �� 5      $��Filter:��6   �� 5      -   5         ��Name$ Filter��5      $	��120��6*   $��15��66   6D   �� 5      $��Search��6   $��3 3 3 3q�6*   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ HttpRecordDataGrid��5         AutoGenerateColumns .  ��64   �� *	Records+ �� SelectedItem 6T   �� *SelectedItem+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 No��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *No+ �� Mode$ OneWay=�  5      $

 Host��6)      MaxWidth$	 200Q�67    6F   �� *Host+$ OneWay=�  5      $
 Method��6)    69   �� *Method+$ OneWay=�  5      $	
 URL��6)   $	 250Q�66    6E   �� *URL+$ OneWay=�4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $
 Params��6-    6=   �� *Params+$ OneWay=�  5       $	
 SSL��6-    6:   �� *SSL+$ OneWay=�  5!      $
 Status��6)    69   �� *Status+$ OneWay=�  5"      $
 Length��6)    69   �� *Length+$ OneWay=�  5#      $
 	Extension��6)    6<   �� *	Extension+$ OneWay=�  5$      $

 MIME��6)    67   �� *MIME+$ OneWay=�  5%      $
 IP��6)    65   �� *IP+$ OneWay=�  5&      $

 Time��6)    67   �� *Time+$ OneWay=�5(      5)      �� 5*   
   $��1��6   $��5��6$   $��Stretch=�6/   6O   �� 5+   
   $��2��6   .@�5,      �� $��Request��6   .��5-      �� -   5        $ RequestText��5-      {�.  �� TextWrapping$
 Wrap=�6@   ��6T   �� *RequestTextContent+$ OneWay=�6�   5.      �� 5/      $��Response��6   .��50      �� -   5        $ ResponseText��50      {�. $
 Wrap=�6A   ��6U   �� *ResponseTextContent+$ OneWay=�6�   51      52      53      54      