   M S B A M L   `   `   `  ����E  ACrazyHacks, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CrazyHacks.ViewCrazyHacks.View  5      T PCefSharp.Wpf, Version=55.0.0.0, Culture=neutral, PublicKeyToken=40c4b6fc221f4138A0clr-namespace:CefSharp.Wpf;assembly=CefSharp.WpfCefSharp.Wpf 5      '    !CrazyHacks.View.ChromeControlView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:CrazyHacks.View     5      EcefSharp0clr-namespace:CefSharp.Wpf;assembly=CefSharp.Wpf     5        � DataContext  5
      ��  �� Path$ ChromeControl�   Locator �� Source# [  .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   � $��0��6    5      �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $	��100 �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��Go��6$   $��Center=�61   6U   �� 5      $��1��6   $��Center=�6&   .��6H    J� InputBindings 5      �� 5      
 �� Key$ Enter��5       �� Command 5       �� $ Address� �� ElementName$ Browser��	 �� CommandParameter	 5!      �� $
 Text�
 �� RelativeSource
 ��  �� Mode$ FindAncestor=� �� AncestorType" ��.��5$   )   5%      5&      %  CefSharp.Wpf.ChromiumWebBrowser  5'   
   -   5          Name$ Browser��5'   3   $��1��6&   $y�Hidden=�6D      Address$ https://www.google.co.kr��5(   
   �� 5*   
   $��2��6   .@�5+      � $��Right=�6   $	��100��5-      $��16��5.      $��3q�5/       � IsIndeterminate 5,      �� *	IsLoading+$ Browser��5/      �� 50      �� 52      ��6   �� *	Address+$ Browser��53      54      55      