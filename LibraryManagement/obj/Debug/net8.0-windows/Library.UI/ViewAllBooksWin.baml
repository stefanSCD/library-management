   M S B A M L   `   `   `  ����L  HLibraryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:LibraryManagement.Library.UILibraryManagement.Library.UI  5   	   2    ,LibraryManagement.Library.UI.ViewAllBooksWin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:LibraryManagement.Library.UI     5   	   -   5          �Name$  ViewAllBooksWindow��5   	    � Title$ View All Books��5   	   $	��600��6    $	��900��6-    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ 	CanResize=�5
   	    � 	Resources 5         PrimaryButtonStyle �� 
TargetType �� Property �� Value  SecondaryButtonStyle  FieldLabelStyle  SearchInputStyle  BooksDataGridStyle&   System.Windows.Controls.DataGrid��%�  &	        &	 �     &	 �    &	     &	 �    �� 5   
   " ��6+   .�5      ��  � �� �#007ACC6+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$
 15,5q�6(   �� 5       � ��$ SemiBold"�6+   5      �� 5   
   " ��6-   .�5      ��  � �� �#EEEEEE6+   �� 5       � ��$ 1q�60   �� 5       � �� �#CCCCCC6,   �� 5       � ��$
 15,5q�6(   5      �� 5   
   " ��6(   .�5      ��  � ��$ SemiBold"�6+   �� 5       � ��$ 0,0,0,5q�6'   5      �� 5!   
   " ��6)   .�5"      ��  � ��$ 30��6'   �� 5#       � ��$	 8,5q�6(   �� 5$       � ��$ 1q�60   �� 5%       � �� �#CCCCCC6,   5&      �� 5(   
   "  6+   .�5)      ��  �@ AutoGenerateColumns$ False��64   �� 5*       �@ 
IsReadOnly$
 True��6+   �� 5+       �@ GridLinesVisibility$ 
Horizontal=�64   �� 5,       �@ RowHeaderWidth$ 0Q�6/   �� 5-       � ��$ 1q�60   �� 5.       � �� �#CCCCCC6,   �� 5/       �@ RowBackground
 �����6.   �� 50        �@ AlternatingRowBackground �#F5F5F569   51      52      .��54      � $��25q�6    � RowDefinitions 55   
   �� 56      $
��Auto �6   �� 57      $
��Auto �6   �� 58      $��* �6   �� 59      $
��Auto �6   .+�5<   
   �� $��0��6   $��0,0,0,20q�6"   .+�5=      �� $��All books from library��6   $��Center=�5>      $��24(�5?      $
��Bold"�6&   ���#3333335@      �� 5A      $��0,10,0,0q�6   ���#DDDDDD6*   5B      � 5D   
   $��1��6   $��0,0,0,15q�6   	 � ColumnDefinitions	 5E      �� 5F      $��* �6#   �� 5G      $
��Auto �6#   �� 5H      $
��Auto �6#   .+�5K      � $��0��6   $��0,0,15,0q�6#   $��Center=�65   	 5L      �� 5M      $
��0.8* �6'   �� 5N      $
��0.2* �6'   .+�5Q      �� -   5        
 ��Name$
 	txtSearch��5Q      $��0��5R      #��[ 5S      $��0,0,10,0q�5T      $��Center=�5U      $��Stretch=�5V      �� 5X      -   5         ��Name$ 	btnSearch��5X      $��1��5Z      $��Search��5[      #��[  5\      $��Stretch=�5]      $��Center=�5^      5_      5a        5c   
   -   5          Name$ dgBooks��5c      $��2��5d      #��[ 5f      ��5e      �� *Books+   Columns 5g      0  *System.Windows.Controls.DataGridTextColumn  5h      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID+6H     5i      $ Title��6%   $ * 6N    64   �� *Title+6N     5j      $ Author��6%   $	 180 6P    65   �� *Author+6P     5k      $ Quantity��6%   $ 70 6T    67   �� *
Quantity+6T     5l      $ 	Available��6%   $ 90 6X    68   �� *Disponibile+6X   5n      � 5p   
   $��3��6   $��0,15,0,0q�6   	 5q      �� 5r      $��* �6#   .+�5u      �� $��0��6    �� Orientation$ 
Horizontal=�6)   .+�5v      �� $��Total books: ��6   $��SemiBold"�61   �� 5w      -   5         ��Name$ txtTotalBooks��5w      $��0��63   �� 5x      $��  Available: ��6   $��15,0,0,0q�61   $��SemiBold"�6C   �� 5y      -   5        $ txtAvailableBooks��5y      $��0��67   �� 5z      $��  Borrowed: ��6   $��15,0,0,0q�60   $��SemiBold"�6B   �� 5{      -   5        $ txtBorrowedBooks��5{      $��0��66   5|      5}      5~      5      