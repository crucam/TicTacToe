   M S B A M L   `   `   `  ����D  @TicTacToe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TicTacToe	TicTacToe  5   	       TicTacToe.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TicTacToe     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ 	TicTacToe��5	   	   $	��500��6   $	��500��6(    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$	 0.7q�60   �� 5       � ��$ 70(�6)   5      5      .��5      � -   5         �Name$ 	Container��5       � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5        	 ��Name$	 btn0_0��5      $��0��6!   $��0��61   6>   �� 5    
   -   5        $	 btn1_0��5       $��1��6!   $��0��61   6>   �� 5!   
   -   5        $	 btn2_0��5!      $��2��6!   $��0��61   6>   �� 5#   
   -   5        $	 btn0_1��5#      $��0��6!   $��1��61   6>   �� 5$   
   -   5        $	 btn1_1��5$      $��1��6!   $��1��61   6>   �� 5%   
   -   5        $	 btn2_1��5%      $��2��6!   $��1��61   6>   �� 5'   
   -   5        $	 btn0_2��5'      $��0��6!   $��2��61   6>   �� 5(   
   -	   5        $	 btn1_2��5(      $��1��6!   $��2��61   6>   �� 5)   
   -
   5        $	 btn2_2��5)      $��2��6!   $��2��61   6>   5+      5,      