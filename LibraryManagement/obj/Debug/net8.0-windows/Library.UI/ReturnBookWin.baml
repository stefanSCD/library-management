   M S B A M L   `   `   `  ����L  HLibraryManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:LibraryManagement.Library.UILibraryManagement.Library.UI  5   	   0    *LibraryManagement.Library.UI.ReturnBookWin   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:LibraryManagement.Library.UI     5   	   -   5          �Name$  ReturnBookWindow��5   	    � Title$ Return Book��5   	   $	��600��6   $	��900��6*    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ 	CanResize=�5
   	    � 	Resources 5         PrimaryButtonStyle �� 
TargetType �� Property �� Value  ReturnButtonStyle  SecondaryButtonStyle  FieldLabelStyle  SearchInputStyle  LoansDataGridStyle&   System.Windows.Controls.DataGrid��%3  &	        &	 �     &	 �    &	 �    &	     &	 �    �� 5   
   " ��6+   .�5      ��  � �� �#007ACC6+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$
 15,5q�6(   �� 5       � ��$ SemiBold"�6+   5      �� 5   
   " ��6*   .�5      ��  � �� �#28A7456+   �� 5       � ��
 �����6+   �� 5       � ��$ 0q�60   �� 5       � ��$
 10,5q�6(   �� 5       � ��$ SemiBold"�6+   5      �� 5   
   " ��6-   .�5      ��  � �� �#EEEEEE6+   �� 5        � ��$ 1q�60   �� 5!       � �� �#CCCCCC6,   �� 5"       � ��$
 15,5q�6(   5#      �� 5$   
   " ��6(   .�5%      ��  � ��$ SemiBold"�6+   �� 5&       � ��$ 0,0,0,5q�6'   5'      �� 5)   
   " ��6)   .�5*      ��  � ��$ 35��6'   �� 5+       � ��$
 10,5q�6(   �� 5,       � ��$ 1q�60   �� 5-       � �� �#CCCCCC6,   �� 5.       � ��$ 14(�6)   5/      �� 51   
   "  6+   .�52      ��  �@ AutoGenerateColumns$ False��64   �� 53       �@ 
IsReadOnly$
 True��6+   �� 54       �@ GridLinesVisibility$ 
Horizontal=�64   �� 55       �@ RowHeaderWidth$ 0Q�6/   �� 56       � ��$ 1q�60   �� 57       � �� �#CCCCCC6,   �� 58       �@ RowBackground
 �����6.   �� 59        �@ AlternatingRowBackground �#F5F5F569   �� 5:       � ��$
 Auto=�6I   �� 5;       � ��$
 Auto=�6K   5<      5=      .��5?      � $��25q�6    � RowDefinitions 5@   
   �� 5A      $
��Auto �6   �� 5B      $
��Auto �6   �� 5C      $��* �6   �� 5D      $
��Auto �6   .+�5G   
   �� $��0��6   $��0,0,0,20q�6"   .+�5H      �� $��Return Books��6   $��Center=�5I      $��24(�5J      $
��Bold"�6&   ���#3333335K      �� 5L      $��0,10,0,0q�6   ���#DDDDDD6*   5M      � 5O   
   $��1��6   $��0,0,0,20q�6   	 � ColumnDefinitions	 5P      �� 5Q      $��* �6#   �� 5R      $
��Auto �6#   .+�5U      � $��0��6   $��0,0,15,0q�6#   	 5V      �� 5W      $��* �6'   �� 5X      $
��Auto �6'   .+�5Z      �� -   5        
 ��Name$
 	txtSearch��5Z      $��0��5[      #��[ 5\      $	��450��5]      $��Stretch=�5^      $��Center=�5_      $��0,0,10,0q�5`      �� 5a      -   5         ��Name$ 	btnSearch��5a      $��1��5c      $��Search��5d      $	��100��5e      $��35��5f      $��14(�5g      $
��Left=�5h      #��[  5i      5j      5k        5m   
   -   5          Name$ dgLoans��5m      $��2��5n      #��[ 5o         Columns 5p      0  *System.Windows.Controls.DataGridTextColumn  5q      ,  &System.Windows.Controls.DataGridColumn   Header$ Loan ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *LoanId+6Q     5r      $ Book ID��6%   $ 80 6Q    66   �� *BookId+6Q     5s      $ Title��6%   $ * 6N    64   �� *Title+6N     5t      $ Author��6%   $ * 6P    65   �� *Author+6P     5u      $ Borrower name��6%   $	 150 6]    6<   �� *BorrowerName+6]     5v      $ Quantity��6%   $ 80 6T    67   �� *
Quantity+6T     5w      $ Borrow date��6%   $	 120 6r    6:   �� *
BorrowDate+ �� StringFormat$ 
dd/MM/yyyy��6r   4  .System.Windows.Controls.DataGridTemplateColumn  5x      $ Actions��6)   $	 100 6:      CellTemplate 5y      �� 5z      .R�5{      �� -   5        $��Return��5{   %   #��[ 5|   !   $��30��5}   !   $��80��5~   !   $��2q�5   !   
 � Tag 5�   !   �� *LoanId+5�   !   5�      5�      5�      5�      5�      