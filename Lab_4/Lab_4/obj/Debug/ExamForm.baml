   M S B A M L   `   `   `  ����@  <Lab_4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab_4Lab_4  5   	       Lab_4.ExamForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Lab_4     5   	     � Title$  	Exam Form��5   	   $	��300��6   $	��400��6(   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ InfoTextBox��5      $��0��6'   $��2��64   $��0��6E   $��5,5,4.6,145q�6U   $��16(�6j    �� 
IsReadOnly . " �� VerticalScrollBarVisibility$
 Auto=�6�    �� TextWrapping$
 Wrap=�6�   �� 5   
   -   5         ��Name$ AddExam��5      $��Додати іспит��6"   $��2��69   $��0��6F   $��5q�6V   $��16(�6a   6o   �� 5   
   -   5         ��Name$
 Exam��5      $��Назва:��6"   	 �� TextAlignment$
	 Left=�60   $��Center=�6E   $��22(�6`   $��2��6n   $��4,98,-4.4,109q�6�   $��1��6�   �� 5   
   -   5        $ Score��5      $��	Бали:��6#   $
	 Left=�60   $��Center=�6E   $��22(�6`   $��2��6n   $��4,133,-3.4,74q�6�   $��1��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        
  Name$
 ExamDatePicker��5      $��22(�6-   $��2��6;   $��1,168.8,-1.4,21q�6O   $��1��6h   �� 5   
   -   5        $ 	Exam_Text��5      $��84,96,1.6,109q�6%   $��1��6<   �� 5   
   -   5        $ 
Score_Text��5      $��85,133,0.6,72q�6&   $��1��6=   5      5      