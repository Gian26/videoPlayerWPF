   M S B A M L   `   `   `  ����I  EvideoPlayerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:videoPlayerWPFvideoPlayerWPF  5   	       videoPlayerWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:videoPlayerWPF     5   	     � Title$  
MainWindow��5   	   $	��300��6   $	��300��6)   $	��300��5	   	    � SizeToContent$ WidthAndHeight=�6   .��5
      � -   5         �Name$ pGrid��5
       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   c� .@�5      �� -   5         ��Name$
 Play��5      $
��PLAY��6#   63   �� 5      -   5        $ Pause��5      $��PAUSE��6$   65   �� 5      -   5        $
 Stop��5      $
��STOP��6#   63   �� 5      -   5        $ Media_B��5      $��	ADD MEDIA��6&   6:   5      r� 5   
   -   5         r�Name$ Player��5       r� LoadedBehavior$ Manual=�6H    r� Stretch$
 Fill=�6`   $��1��6q   6�   �� 5   
   $��2��6   ��5      �� 5      .R�5      �  � ColumnDefinitions 5      �� 5      $
��Auto �6/   �� 5      $��3* �6/   �� 5       $��* �6/   5"      5#      .@�5,      �� .��5-      �� -   5        $��lblProgressStatus��5-      
00:00:006?   5.      �� 56      $��1��6   $��Stretch=�6,   .��57      �� -   5        $��sliProgress��57      6�   58      �� 5K      $��2��6   $��Stretch=�6,   .��5L      �� -	   5        $��volumeSlider��5L      	 � Minimum$	 0Q�5M      
 � Maximum$
 1Q�6     � Value$	 0.1Q�6,   5N      5O      5P      5Q      