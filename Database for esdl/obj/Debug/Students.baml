   M S B A M L   `   `   `  ����L  HDatabase for esdl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Database_for_esdlDatabase_for_esdl  5   	        Database_for_esdl.Students   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Database_for_esdl     5   	     � Title$  Library Members��5   	   $	��768��6!   $
��1366��6.    � WindowState$ 	Maximized=�6;    � Icon$ library.ico��6T   .��5	      � $��0,0,-8,0q�6   ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ 
WhiteSmoke��6   � 5      $ 	#FF928430��6   $ 0.161Q�61   5       � RowDefinitions 5   
   �� 5      $
��501* �6   �� 5      $
��236* �6   .+�5   
   �� -   5         ��Name$ textBox1��5      $
��Left=�6$   $��23��6?   $��	10,45,0,0q�6K   	 �� TextWrapping$
	 Wrap=�6^   $	��Top=�6r   $	��120��6�   �� 5   
   -   5        $ textBox2��5      $
��Left=�6$   $��23��6?   $��
155,45,0,0q�6K   $
	 Wrap=�6_   $	��Top=�6s   $	��120��6�   �� 5   
   -   5        $ textBox4��5      $
��Left=�6$   $��23��6?   $��
299,45,0,0q�6K   $
	 Wrap=�6_   $	��Top=�6s   $	��120��6�   
 J� RenderTransformOrigin$
 3.358,0.435&�6�   �� 5   
   -   5        $ textBox6��5      $
��Left=�6$   $��23��6?   $��
748,45,0,0q�6K   $
	 Wrap=�6_   $	��Top=�6s   $	��120��6�   �� 5   
   -   5         ��Name$ button��5      $	��Add��6!   $
��Left=�6/   $��
903,45,0,0q�6J   $	��Top=�6^   $��97��6v   $��23��6�   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ Black��6#   $ 0Q�61   � 5      $ White��6#   $ 0.009Q�61   � 5      $ 	#FFA08989��6#   $ 0.678Q�65   5      5!      �� 5"   
   -   5         ��Name$ 
textBlock1��5"      $
��Left=�6(   $��	10,19,0,0q�6C   $
��Wrap=�6V   $��User ID��6j   $	��Top=�6y   $	��120��6�    �� TextAlignment$ Center=�6�   �� 5#   
   -   5        $ textBlock1_Copy1��5#      $
��Left=�6.   $��
746,19,0,0q�6I   $
��Wrap=�6]   $��	Mobile No��6q   $	��Top=�6�   $	��120��6�   $ Center=�6�   �� 5$   
   -   5        $ textBlock1_Copy2��5$      $
��Left=�6.   $��
448,19,0,0q�6I   $
��Wrap=�6]   $	��Top=�6q   $	��120��6�   $ Center=�6�   �� 6�   $�Class��6�   �� 6�   �� 6�   6�   �� 5%   
   -	   5        $ textBlock1_Copy3��5%      $
��Left=�6.   $��
301,19,0,0q�6I   $
��Wrap=�6]   $��Address��6q   $	��Top=�6�   $	��120��6�   $ Center=�6�   �� 5&   
   -
   5        $ textBlock1_Copy5��5&      $
��Left=�6.   $��
155,19,0,0q�6I   $
��Wrap=�6]   $
��Name��6q   $	��Top=�6}   $	��120��6�   $ Center=�6�   �� 5'   
   -   5        $ textBox7��5'      $
��Left=�6$   $��23��6?   $��1067,44,0,0q�6K   $
	 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5(   
   -   5        $ textBlock1_Copy6��5(      $
��Left=�6.   $��1067,23,0,0q�6I   $
��Wrap=�6^   $��User ID��6r   $	��Top=�6�   $	��120��6�   $ Center=�6�   �� 5)   
   -   5        $ button1��5)      $��Delete��6"   $
��Left=�63   $��1214,45,0,0q�6N   $	��Top=�6c   $	��120��6{   $��23��6�   ��5*      �� 5+      $ 0.5,1&�6&   $ 0.5,0&�67   .��5,      � $ Black��6#   $ 0Q�61   � 5-      $ White��6#   � 5.      $ 	#FFAE5252��6#   � 5/      $ 	#FFAE5252��6#   � 50      $ 	#FFD8ADAD��6#   � 51      $ White��6#   � 52      $ White��6#   � 53      $ 	#FFB09999��6#   $ 0.591Q�65   � 54      $ White��6#   55      57      &   System.Windows.Controls.DataGrid  58   
   -   5          Name$ grid1��58      $
��Left=�6"   $��0,90,0,0q�6=   $	��Top=�6O   $	��647��6g   $
��1366��6t   $��2��6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 200 6�   
���������59      �� 5:      $ 0.5,1&�6&   $ 0.5,0&�67   .��5;      � $ Black��6#   $ 0Q�61   � 5<      $ White��6#   � 5=      $ 	#FFEEA18A��6#   $ 0.448Q�65   5>      5@      �� 5A   
   
���   �$��1q�6%   $
��Left=�69   $��2��6T   $��0,85,0,0q�6_   $	��Top=�6q   $
��1365��6�   $
 0.5,0.5&�6�   z�5B      V� 5C      .~�5D      ��  �� ScaleY$ -1Q�6%   �� 5E      �� 5F      T� 5G      5H      5J      �� 5K   
   
���   �$��1q�6%   $
��Left=�69   $��78��6T   $��0,8,0,0q�6`   $	��Top=�6q   $��2��6�   $
 0.5,0.5&�6�   z�5L      V� 5M      .~�5N      �� $ -1Q�6%   �� 5O      �� 5P      T� 5Q      5R      5T      �� 5U   
   -   5         ��Name$ 	comboBox1��5U      $
��Left=�6&   $��
448,45,0,0q�6A   $	��Top=�6U   $	��120��6m   $��23��6y   �� 5V   
   -   5        $ textBlock1_Copy��5V      $
��Left=�6-   $��
600,19,0,0q�6H   $
��Wrap=�6\   $	��Top=�6p   $	��120��6�   $ Center=�6�   $��Branch��6�   �� 5W   
   -   5        $ 	comboBox2��5W      $
��Left=�6&   $��
600,45,0,0q�6A   $	��Top=�6U   $	��120��6m   $��23��6y   �� 5X   
   
���   �$��1q�6%   $
��Left=�69   $��2��6T   $��2,3,0,0q�6_   $	��Top=�6p   $
��1369��6�   $
 0.5,0.5&�6�   z�5Y      V� 5Z      .~�5[      �� $ -1Q�6%   �� 5\      �� 5]      T� 5^      5_      5a      �� 5b   
   
���   �$��1q�6%   $
��Left=�69   $��78��6T   $��0,4,0,0q�6`   $	��Top=�6q   $��2��6�   $
 0.5,0.5&�6�   z�5c      V� 5d      .~�5e      �� $ -1Q�6%   �� 5f      �� 5g      T� 5h      5i      5k      �� 5l   
   
���   �$��1q�6%   $
��Left=�69   $��80��6T   $��
1363,3,0,0q�6`   $	��Top=�6t   $��2��6�   $
 0.5,0.5&�6�   z�5m      V� 5n      .~�5o      �� $ -1Q�6%   �� 5p      �� 5q      T� 5r      5s      5u      �� 5v   
   
���   �$��1q�6%   $
��Left=�69   $��80��6T   $��
1046,4,0,0q�6`   $	��Top=�6t   $��2��6�   $
 0.5,0.5&�6�   z�5w      V� 5x      .~�5y      �� $ -1Q�6%   �� 5z      �� 5{      T� 5|      5}      5      5�      5�      