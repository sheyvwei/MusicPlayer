   M S B A M L   `   `   `  ����R  NWpfCustomControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:WpfCustomControlLibrary.Controls WpfCustomControlLibrary.Controls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source   TabButton_Template �� 
TargetType0    *WpfCustomControlLibrary.Controls.TabButton ��Name �� RelativeSource �� Mode �� Path �� CornerRadius �� Orientation	 ��Name
 J� RenderTransformOrigin  Icon �� Angle �� Triggers P� Property P� Value �� 
TargetName �� Value �� Property ]� 
Conditions �� Property �� Value N� EnterActions �� 
TargetName �� TargetProperty	 W� To g� Duration N� ExitActions  DefaultTabButtonStyle �� 
TargetType  ButtonForeground  ButtonMouseOverBackground  ButtonMouseOverForeground  ButtonCheckedForeground  TwoColor �� BasedOn�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      8local.clr-namespace:WpfCustomControlLibrary.Controls  5        5      �� 5   
   $N Hpack://application:,,,/WpfCustomControlLibrary;component/Style/Icon.xaml?�6   �� 5   
   $P Jpack://application:,,,/WpfCustomControlLibrary;component/Style/Colors.xaml?�6   %�  &	        7  &	 c	    7  7  7  7  7  7   '   o    7  �� 5      "   61   .R�5
   
   �� $ border��6   #��z��5      #��z��6=   ��5
   !   ��  �� $ TemplatedParent=�$ 
Background���5      ��  �� $ TemplatedParent=�$ Height� 5      ��  �� $ TemplatedParent=�$ CornerRadius���5      ��  �� $ TemplatedParent=�$ Width�._�5      �� $ 
Horizontal=�6   $��Center=�62   #��z��5      #��z��5      .+�5      �� $
	 icon��6   $
 0.5, 0.5&�5      8��  ��5   *   ��  �� $ TemplatedParent=�$ 
IconMargin���5      ��  �� $ TemplatedParent=�$ 	MusicIcon���5      ��  �� $ TemplatedParent=�$ IconSize���5      ��  �� $ TemplatedParent=�$ 
Foreground�z�5      �� 5      	transIcon��$ 0Q�6=   6I   5      �� 5       $		 txt��67   $��Center=�6   ��5!      ��  �� $ TemplatedParent=�$ ContentDecorations���5"      ��  �� $ TemplatedParent=�$ Content���5#      ��  �� $ TemplatedParent=�$ FontSize���5$      ��  �� $ TemplatedParent=�$ 
Foreground�5%      5&       5(   
   P� 5*       �@J�IsMouseOver . . �5+      �� $ border��6�    6/   ��  �� $ TemplatedParent=�$ MouseOverBackground� � ��6�   �� 5,      $
 icon��6�    6/   ��  �� $ TemplatedParent=�$ MouseOverForeground� � ��6�   �� 5-      $	 txt��6�    6/   ��  �� $ TemplatedParent=�$ MouseOverForeground� � ��6�   5.      P� 50       �@d�	IsChecked$
 TrueY�6+   . �51      �� $ border��6�    6/   ��  �� $ TemplatedParent=�$ CheckedBackground� � ��6�   �� 52      $
 icon��6�    6/   ��  �� $ TemplatedParent=�$ CheckedForeground� � ��6�   �� 53      $	 txt��6�    6/   ��  �� $ TemplatedParent=�$ CheckedForeground� � ��6�   54      ]� 55       56      �� 58       �@J�IsMouseOver . 67   �� 59       �@  AllowsAnimation . 6;    5<      �� 5=      .��5>      �� .��5?      W� $ 	transIcon��6.   $ Angle�6P   $	 180X�6r   $ 0:0:0.2D�6{   5@      5A       5D      �� 5E      .��5F      �� .��5G      W� $ 	transIcon��6.   $ Anlge�6P   $ 0X�6r   $ 0:0:0.2D�6y   5H      5I      5K      5M      �� 5P      "   6*   .�5Q   
   ��  � ��
 ���� 6'   �� 5R   
    � ��8   6'   �� 5S   
    �@  MouseOverBackground8  60   �� 5T   
    �@  MouseOverForeground8  60   �� 5U   
    �@  CheckedForeground8  6.   �� 5V   
    �@  CheckedBackground8  6.   �� 5W   
    � ��$ Center=�60   �� 5X   
    � ��$ 25��6#   �� 5Y   
    �@  IconSize$ 12��6%   �� 5Z   
    � ��$ 10(�6%   �� 5[   
    � ��$ 15, 2, 15, 2q�6$   �� 5]   
    � �� 6$   Z� �� 5^   
    �@  
IconMargin$ 0, 0, 10, 0q�6'   �� 5_   
    �@  AllowsAnimation .  6,   �� 5`   
    �@  CornerRadius$ 0��6)   �� 5b   
    �@�Cursor$
 Hand��6#   �� 5c   
    � ��8  6%   5d      �� 5f      "   6   8   62   5g      