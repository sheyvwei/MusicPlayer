   M S B A M L   `   `   `  ���� F  BMusicPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MusicPlayerMusicPlayer  =#clr-namespace:MusicPlayer.ViewModelMusicPlayer.ViewModel  R NWpfCustomControlLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulltOclr-namespace:WpfCustomControlLibrary.Controls;assembly=WpfCustomControlLibrary WpfCustomControlLibrary.Controls     MusicPlayer.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:MusicPlayer     2vm#clr-namespace:MusicPlayer.ViewModel     bCustomOclr-namespace:WpfCustomControlLibrary.Controls;assembly=WpfCustomControlLibrary       � WindowStartupLocation$  CenterScreen=� � WindowStyle$
 None=� � Title$ 	云音乐��$	��535��$	��815�� � 
ResizeMode$ NoResize=� � DataContext �� *Main+   Locator �� Source# [  .���  � RowDefinitions �� $��40 ��� $��* ��� $��40 �.+��� $��Stretch=�$��Stretch=�$��0q�
�������$��2��� -   $��0��
���� �� � ColumnDefinitions �� $	��150 ��� $��* ��� $
��auto �.+��� $��0�� �� Orientation$ 
Horizontal=�$
��Left=�$��Center=�.+�2  ,WpfCustomControlLibrary.Controls.MusicButton  	   	MusicIcon$		 ��.��	云音乐� $��1���� $��2��$ 
Horizontal=�$��Right=�$��Center=�.+�  $		 ��  OnlyIcon#��[ 
 � ToolTip$
 皮肤��  $		 ��#��[ $
 设置���� 
�������$��Stretch=�.��|  -   $		 ��#��[ $
 	最小化��  -   $		 ��#��[ $
 	最大化��  -   $		 ��#��[ $
 关闭��� $��1�� �� $	��160 ��� $��* �.+��� $��0��$��Visible=�.���� $ Vertical=�.+��� ���#A7A7A7$��10, 0, 0, 0q�$��25��$��Center=�.��推荐0  *WpfCustomControlLibrary.Controls.TabButton     	MusicIcon$	 ��$��Stretch=� 	� 	GroupName$ 	tabButton������ *FindMusicCommand+.��发现音乐  $	 ��$��Stretch=�$ 	tabButton��.��
私人FM  $	 ��$��Stretch=�$ 	tabButton��.��MV  $	 ��$��Stretch=�$ 	tabButton��.��朋友�� 
�������.��我的音乐  $	 ��$��Stretch=�$ 	tabButton������ *LocalMusicCommand+.��本地音乐  $	 ��$��Stretch=�$ 	tabButton��.��下载管理  $	 ��$��Stretch=�$ 	tabButton��.��我的收藏�� $��创建的歌单��
�������$��Center=�  $	 ��$��Stretch=�$ 	tabButton��.��我喜欢的音乐� $��1��.+��� ���� *CurrentPageViewModel+� $��2�� �� $	��150 ��� $��2* ��� $��* �.+��� $ 
Horizontal=�.+�  $		 ��  LastOrNextStyle#��[ $��25, 0, 0, 0q�  $		 ��  	PlayStyle#��[ $��20, 0, 0, 0q����� # [   �� Path$$ LocalMusic.PlayAndPauseCommand�  $		 ��#��[ $��20, 0, 0, 0q�