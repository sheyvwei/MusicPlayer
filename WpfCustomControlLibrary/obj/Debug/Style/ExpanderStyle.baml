   M S B A M L   `   `   `  ����R  NWpfCustomControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:WpfCustomControlLibrary.Controls WpfCustomControlLibrary.Controls  5      M+clr-namespace:WpfCustomControlLibrary.StyleWpfCustomControlLibrary.Style  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ExpanderToggleButton  �� 
TargetType �� CornerRadius2    ,WpfCustomControlLibrary.Controls.MusicButton   Name    	MusicIcon  ExpanderIcon �� Triggers P� Property P� Value �� 
TargetName �� Property	 �� Value  Expander
 �� 
TargetType � RowDefinitions �Name � ColumnDefinitions � OverridesDefaultStyle d� 	IsChecked �� Path �� Mode �� RelativeSource �� ElementName�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      9Custom.clr-namespace:WpfCustomControlLibrary.Controls  5      5local+clr-namespace:WpfCustomControlLibrary.Style  5      %q  &	        7  &	 �    7   �� 5      "  d�63   .R�5   
   �� $��border��6   $ 
2, 0, 0, 0��6   
������ $��
0, 0, 1, 0q�6R   ._�5         $ expander��6!   $	 ��63   8��  6I   5       5	   
   P� 5
       �@d�	IsChecked$
 trueY�6+   . �5      �� $ expander��6    �@  	MusicIcon$		 ��6E   5      P� 5       �@d�	IsChecked$ falseY�6+   . �5      �� $ expander��6    �@  	MusicIcon$		 ��6D   5      5      �� 5      "
 9�6   .�5   
   ��  � ��	 5      �� 5      "  9�6"   .R�5      �  5      �� 5      $ content��6,   $
��Auto �6;   �� 5      $ 
ContentRow��6,   $��0 �6>   .+�5      �� $��Border��6!   $��0��6/   $��1q�6<   $ 
2, 2, 0, 0��6P   ._�5      �  5   "   �� 5   &   $��* �67   �� 5   &   $��20 �67   .+�5!   "   d� $��Right=�6/    . 8��  $��1��5"   {    5!   L   �� $ 
IsExpanded�$ TwoWay=� �� *TemplatedParent+5$   #   �� 5%   "   $��0��63   $��4q�6C   $��Header��6N   ��. 6e   5&      5'      �� 5(      $��Content��6!   $��1��60   $ 0,0,2,2��6=   ._�5)      �� 5*      5+       5,      P� 5-       �@9�
IsExpanded . . �5.      �� $ 
ContentRow��6%   	 6O   �� $ Content��$ DesiredHeight� � ��5/      51      53      54      55      