   M S B A M L   `   `   `  ����L  HLibraryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:LibraryManagement.Library.UILibraryManagement.Library.UI  5   	   1    +LibraryManagement.Library.UI.ManageBooksWin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:LibraryManagement.Library.UI     5   	   -   5          �Name$  ManageBooksWindow��5   	    � Title$ Gestionare Cărți��5   	   $	��700��6"   $
��1000��6/    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ 	CanResize=�5
   	    � 	Resources 5         PrimaryButtonStyle �� 
TargetType �� Property �� Value  DeleteButtonStyle  EditButtonStyle  SecondaryButtonStyle  FieldLabelStyle  SearchInputStyle  FieldInputStyle  BooksDataGridStyle&   System.Windows.Controls.DataGrid  ManageBoxStyle��%�	  &	        &	     &	     &	     &	     &	 �    &	 }    &	 [    &	 �    �� 5   
   " ��6+   .�5      ��  � �� �#007ACC6+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$
 10,2q�6(   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$ 12(�6)   5      �� 5   
   " ��6*   .�5      ��  � �� �#DC35456+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$	 8,2q�6(   �� 5       � ��$ SemiBold"�6+   �� 5       � ��$ 12(�6)   5      �� 5!   
   " ��6(   .�5"      ��  � �� �#17A2B86+   �� 5#       � ��
 �����6+   �� 5$       � ��$ 0q�60   �� 5%       � ��$	 8,2q�6(   �� 5&       � ��$ SemiBold"�6+   �� 5'       � ��$ 12(�6)   5(      �� 5*   
   " ��6-   .�5+      ��  � �� �#EEEEEE6+   �� 5,       � ��$ 1q�60   �� 5-       � �� �#CCCCCC6,   �� 5.       � ��$
 10,2q�6(   �� 5/       � ��$ 12(�6)   50      �� 52   
   " ��6(   .�53      ��  � ��$ SemiBold"�6+   �� 54       � ��$ 0,0,0,2q�6'   �� 55       � ��$ 12(�6)   56      �� 58   
   " ��6)   .�59      ��  � ��$ 28��6'   �� 5:       � ��$	 8,2q�6(   �� 5;       � ��$ 1q�60   �� 5<       � �� �#CCCCCC6,   �� 5=       � ��$ 12(�6)   5>      �� 5@   
   " ��6(   .�5A      ��  � ��$ 24��6'   �� 5B       � ��$	 6,2q�6(   �� 5C       � ��$ 1q�60   �� 5D       � �� �#CCCCCC6,   �� 5E       � ��$ 12(�6)   5F      �� 5H   
   "  6+   .�5I      ��  �@ AutoGenerateColumns$ False��64   �� 5J       �@ 
IsReadOnly$
 True��6+   �� 5K       �@ GridLinesVisibility$ 
Horizontal=�64   �� 5L       �@ RowHeaderWidth$ 0Q�6/   �� 5M       � ��$ 1q�60   �� 5N       � �� �#CCCCCC6,   �� 5O       �@ RowBackground
 �����6.   �� 5P        �@ AlternatingRowBackground �#F5F5F569   �� 5Q       � ��$
 Auto=�6I   �� 5R       � ��$
 Auto=�6K   �� 5S       � ��$ 12(�6)   5T      �� 5V   
   " ��6'   .�5W      ��  � �� �#CCCCCC6,   �� 5X       � ��$ 1q�60   �� 5Y       � ��$ 0,10,0,0q�6'   �� 5Z       � ��$ 8q�6(   �� 5[       � ��$ 12(�6)   5\      5]      .��5_      � $��15q�6    � RowDefinitions 5`   
   �� 5a      $
��Auto �6   �� 5b      $
��Auto �6   �� 5c      $��* �6   �� 5d      $
��Auto �6   �� 5e      $
��Auto �6   .+�5h   
   �� $��0��6   $��0,0,0,10q�6"   .+�5i      �� $��Manage Books��6   $��Center=�5j      $��20(�5k      $
��Bold"�6&   ���#3333335l      �� 5m      $��0,5,0,0q�6   ���#DDDDDD6)   5n      � 5p   
   $��1��6   $��0,0,0,10q�6   	 � ColumnDefinitions	 5q      �� 5r      $��* �6#   �� 5s      $
��Auto �6#   �� 5t      $
��Auto �6#   .+�5w      � $��0��6   $��0,0,10,0q�6#   	 5x      �� 5y      $��* �6'   �� 5z      $
��Auto �6'   .+�5|      �� -   5        
 ��Name$
 	txtSearch��5|      $��0��5}      #��[ 5~      $	��400��5      $��Stretch=�5�      $��Center=�5�      $��0,0,5,0q�5�      �� 5�      -   5         ��Name$ 	btnSearch��5�      $��1��5�      $��Search��5�      $��80��5�      $��28��5�      $
��Left=�5�      #��[  5�      5�      �� 5�      -   5        $ btnAddNewBook��5�      $��2��5�      $��Add Book��5�      $	��110��5�      $��28��5�      #��[  5�      5�        5�   
   -   5          Name$ dgBooks��5�      $��2��5�      #��[ 5�      $��0,0,0,10q�5�      ��5�      �� *Books+   Columns 5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+6H     5�      $ Title��6%   $ * 6N    64   �� *Title+6N     5�      $ Author��6%   $	 180 6P    65   �� *Author+6P     5�      $ Quantity��6%   $ 70 6T    67   �� *
Quantity+6T   5�      � 5�   
   $��3��6   $��0,0,0,10q�6   	 5�      �� 5�      $��* �6#   �� 5�      $��* �6#   .+�5�      �� $��0��6   $��Update Book��5�      #��[ 5�      $��0,0,5,0q�5�      .��5�      � 	 5�      �� 5�      $
��Auto �6+   �� 5�      $��* �6+    5�      �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   .+�5�      �� $��0��6    $��0��6-   $��Book ID:��6=   #��[ 6M   $��0,4,10,4q�6v   �� 5�      -   5        $
 	txtEditId��5�   ;   $��0��6   $��1��6+    �� 
IsReadOnly$
 True��6N   #��[ 6`   $��0,4,0,4q�6�   �� 5�      $��1��6    $��0��6-   $��Title:��6=   #��[ 6K   $��0,4,10,4q�6t   �� 5�      -   5        $
 txtEditTitle��5�   ;   $��1��6   $��1��6+   #��[ 6Q   $��0,4,0,4q�6z   �� 5�      $��2��6    $��0��6-   $��Author:��6=   #��[ 6L   $��0,4,10,4q�6u   �� 5�      -   5        $
 txtEditAuthor��5�   ;   $��2��6   $��1��6+   #��[ 6R   $��0,4,0,4q�6{   �� 5�      $��3��6    $��0��6-   $��	Quantity:��6=   #��[ 6N   $��0,4,10,4q�6w   �� 5�      -	   5        $
 txtEditQuantity��5�   ;   $��3��6   $��1��6+   #��[ 6T   $��0,4,0,4q�6}   �� 5�      -
   5        $ btnSaveChanges��5�      $��4��5�      $��1��6*   $
��Save��5�      $��28��5�      $��0,5,0,0q�5�      $��Right=�5�      $	��140��5�      #��[ 5�      5�      5�      �� 5�      $��1��6   $��Delete Book��5�      #��[ 5�      $��5,0,0,0q�5�      .��5�      � 	 5�      �� 5�      $
��Auto �6+   �� 5�      $��* �6+    5�      �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   �� 5�      $
��Auto �6(   .+�5�      �� $��0��6    $��0��6-   $��Book ID:��6=   #��[ 6M   $��0,4,10,4q�6v   �� 5�      -   5        $
 txtDeleteId��5�   ;   $��0��6   $��1��6+   $
 True��6P   #��[ 6b   $��0,4,0,4q�6�   �� 5�      -   5        $ btnDeleteBook��5�      $��3��5�      $��1��6*   $��Delete��5�      $��28��5�      $��0,5,0,0q�5�      $��Right=�5�      $	��110��5�      #��[ 5�      5�      5�      5�      �� 5�   
   $��4��6   $-��'* Double click on row for autocomplete.��5�      $��11(�5�      $��0,0,0,5q�5�      $��Italic$�5�      5�      5�      