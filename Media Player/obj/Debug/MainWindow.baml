   M S B A M L   `   `   `  ����I  EMahApps.Metro, Version=1.3.0.60, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5       Media Player   MediaPlayer.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6T     � Title$  	TR PLAYER��5      $��UltraCondensed&�6)   ���	#FF202123(   "MahApps.Metro.Controls.MetroWindow   ShowIconOnTitleBar . $	��450��6x   $	��600��6�   $	��450��6�   $	��600��6�   ���	#FF202123 � 
ResizeMode$ CanResizeWithGrip=�6�      TitleForeground
 �����$y�Visible=�6�    � AllowsTransparency .  � WindowStyle$
 None=�6-   � 	Resources 5       �� MergedDictionaries �� Source�� 5	   
    5
      �� 5      $ /Resources/Icons.xaml?�6%   %    5      	   Flyouts	 5      +   %MahApps.Metro.Controls.FlyoutsControl  5   
   .@�5      #   MahApps.Metro.Controls.Flyout  -   5        
  Name$
 maFlyout��5         Header$ Playing��60      Position$ Right=�6A   $	��250��6R   .��5      �� -   5         ��Name$ listBox��5       5         listBoxItemContextMenu��%[   &	        �� 5      .@�5      m� -   5        $��Delete��5   '   6P   5      5      ��5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property �@�ContextMenu �� Value# [  6<   5      5      5      5          RightWindowCommands 5#      +   %MahApps.Metro.Controls.WindowCommands  5$   
   .@�5%      d� $��Playlist��6    � Cursor$
 Hand��6a    d� 	IsChecked 6.   �� *IsOpen+ �� ElementName$ maFlyout��6a   5&      .��5)      � -   5         �Name$ gridMP��5)      $��0q�6   
������  J� 	AllowDrop . $
��Auto��6_   $
��Auto��6l   $��Bottom=�6z    � RowDefinitions 5*   
   �� 5+      $��0 �6   �� 5,      $
��auto �6   $	��375��6*   �� 5-      .+�5/   
   �� 
������  �� ResizeDirection$
 Rows=�61   $��Stretch=�6H   $��0q�6f   $��0��6r   $��1��6�   $��Stretch=�6�   $
��auto��6�   $��1��6�   r� 50   
   -   5         r�Name$ mePlayer��50      $
��Auto��6)   $��0q�67   $
��Auto��6B   $��0��6O   $��0��6_   $��1��6l   $��2��6�    r� ScrubbingEnabled . 6�   � 51   
   $��Stretch=�6   $��2��60   $��0��6=   $��1��6M   $��1��6a   $
��auto��6r    � ColumnDefinitions 52      �� 53      �� 54      �� 55      �� 56      �� 57      �� 58      �� 59      �� 5:      �� 5;      $
��0.5* �6#   �� 5<      �� 5=      �� 5>      $
��0.5* �6#   .+�5@      �� -   5         ��Name$ btnPlayPause��5@      $
��Play��6+   $��Stretch=�6;   $��0q�6Y   
����������	#FF202123$��0��6�   $��1��6�   $��1��6�   ��6   Z� 6�   �� 5A      -   5        $ btnStop��5A      $
��Stop��6&   $��Stretch=�65   $��0q�6S   $��Stretch=�6^   $
��auto��6z   $
��auto��6�   ���	#FF202123
�������$��1��6�   $��2��6�   $��1��6
  $��1��6  ��6�   Z� 6  (� 5B      $��Stretch=�6   $��0q�64   $��Stretch=�6?   $
��Auto��6[   $
��Auto��6h   $��2��6v   $��2��6�   $��1��6�   $��1��6�   .��5C      �� -   5         ��Name$ lblSeek��5C      $��00:00:00��6)   $��Stretch=�6<   $��0q�6Z   $��Stretch=�6e   $
��Auto��6�   $
��Auto��6�   $��2��6�   $��2��6�   $��1��6�   $��1��6�   $��Times New Roman)�6�   $��11(�6�   $
��Bold"�6	   J� RenderTransformOrigin$ 0.081,0.593&�6  ���	#FF202123���	#FFF3F1F16V  5D      �� 5E      -	   5         ��Name$ sliSeek��5E      $��Stretch=�6|   $��0q�6�   $��Stretch=�6�   $
��Auto��6�   $��22��6�   |�.  $
 Hand��6�     �� IsMoveToPointEnabled  . ! �� IsSelectionRangeEnabled! . $��3��6x  $��2��6�  $��4��6�  $��1��6�  ��65  Z� ��6K  Z� ��6b  Z� 6�  (� 5F      $��Stretch=�6   $��0q�64   $��Stretch=�6?   $
��Auto��6[   $
��Auto��6h   $��7��6v   $��2��6�   $��1��6�   $��1��6�   .��5G      �� -
   5        $ lblTotalSeek��5G      $��00:00:00��6.   $��Stretch=�6A   $��0q�6_   $��Stretch=�6j   $ 0.375,0.452&�6�   $
��Auto��6�   $
��Auto��6�   $��7��6�   $��2��6�   $��1��6�   $��1��6�   $��Times New Roman)�6  $��11(�6$  $
��Bold"�62  ���	#FFF1E8E86D  5H      (� 5I      $��Stretch=�6   $��0q�64   $��Stretch=�6?   $
��Auto��6[   $
��Auto��6h   $��8��6v   $��2��6�   $��1��6�   $��1��6�   .��5J      d� -   5        " d�Name$" tBtnMute��5J         MetroCircleToggleButtonStyle#���  61   $��Stretch=�6h   $��Stretch=�6�   $��	5,-2,6,-1q�6�   $��50��6�   $��50��6�   $��8��6�   $��1��6�   $��1��6  
�������.��5K      �� $��25��6    $��25��6+   #��� ��67   # J� OpacityMask# 5L      !� 5M      $ j� Stretch$
$ Fill=�6*     appbar_sound_mute% !� Visual#% �  69   5O      5P      5Q      �� 5R      -   5        $ sliVol��5R      $��Stretch=�6}   $��0q�6�   $��Stretch=�6�   $
��Auto��6�   $��21��6�   & � Maximum$	& 100Q�6�   $ 0.556,-0.12&�6�   ���	#FFFBFBFB
# �   �' �� AutoToolTipPlacement$' BottomRight=�6N  $
 Hand��6�    . $��9��6�  $��2��6�  $��2��6�  $��1��6�  ��6  Z� 6�  (� 5S      $��Stretch=�6   $��0q�64   $��Stretch=�6?   $
��Auto��6[   $
��Auto��6h   $��11��6v   $��2��6�   $��1��6�   $��1��6�   .��5T      d� -   5        $" 
tBtnExpand��5T      #���  63   $��Stretch=�6j   $��Stretch=�6�   $��	5,-2,6,-1q�6�   $��50��6�   $��50��6�   $��11��6�   $��1��6�   $��1��6  .��5U      �� $��25��6    $��25��6+   
�������# 5V      !� 5W      $
$ Fill=�6*     appbar_arrow_expand#% �  69   5Y      5Z      5[      5\      5]      5^      