   M S B A M L   `   `   `  ����L  HwhoWillCleanToday, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:whoWillCleanTodaywhoWillCleanToday  5   	   "    whoWillCleanToday.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:whoWillCleanToday     5   	   -   5          � Title$  Who will clean today?��5   	   $	��500��6'   $	��892��64   
�������$
��1000��6S   $	��600��6c    � WindowStyle$
 None=�6s    � AllowsTransparency$
 True��6�    � 
ResizeMode$ NoResize=�6�   .��5	      � $	��600��6   $
��1000��6   $
��1000��6%   $	��600��65   .+�5
   
   �� -   5         ��Name$ button_exit��5
      $��X��6&   $��958,10,10,558q�62   $��32��6I   $��32��6T   
�������$��Arial)�6t   $
��Bold"�6�   $��20(�6�   ���	#FFC8C8C8$��32��6�   $��32��6�   $��32��6�   $��32��6�   $��Right=�6  ��5      �� 5      5      �� 5   
   -   5         ��Name$ ListBox_studentList��5      $��173,95,628,385q�6Z   $��NanumGothic)�6r   ���	#FFDEE6FF���	#FF4343436�   �� 5   
   -   5        $ ListBox_exceptionList��5      $��173,326,628,154q�6\   $��NanumGothic)�6u   ���	#FFDEE6FF���	#FF4343436�   �� 5   
   -   5         ��Name$ Label_studentList��5      $��전체 학생 목록��6+   $��199,54,0,510q�6>   $��NanumGothic)�6T   $��22(�6m   $��DemiBold"�6{   $
��Left=�6�   ���	#FF3232326�   �� 5   
   -   5        $ Label_studentList_Copy��5      $��청소 면제자 목록��60   $��189,285,0,279q�6D   $��NanumGothic)�6[   $��22(�6t   $��DemiBold"�6�   $
��Left=�6�   ���	#FF3232326�   �� 5   
   $��	0,0,839,0q�6   ���	#FFF4F4F46$   �� 5   
   -   5        $ Button_AddStudent��5      $��추가��6,   $��173,224,728,326q�69   ���	#FFE4E4E4$��NanumGothic)�6�    � Cursor$
 Hand��6�   ��6�   Z� 6�   �� 5   
   -   5        $ Button_RemoveStudent��5      $��삭제��6/   $��277,224,628,326q�6<   ���	#FFE4E4E4$��NanumGothic)�6�   $
 Hand��6�   ��6m   Z� 6�   �� 5   
   -	   5        $ Button_AddException��5      $��추가��6.   $��173,451,728,99q�6;   ���	#FFE4E4E4$��NanumGothic)�6�   $
 Hand��6�   ��6�   Z� 6�   �� 5   
   -
   5        $ Button_RemoveException��5      $��삭제��61   $��277,451,628,99q�6>   ���	#FFE4E4E4$��NanumGothic)�6�   $
 Hand��6�   ��6n   Z� 6�   �� 5   
   -   5        $ Label_studentNumber��5      $��전체 학생 수 : ��6-   $��173,507,628,62q�6C   $��NanumGothic)�6[   ���	#FF3232326t   �� 5   
   -   5        $ Label_exceptionNumber��5      $��청소 면제자 수 : ��6/   $��173,533,628,35q�6F   $��NanumGothic)�6^   ���	#FF3232326w   �� 5   
   -   5        $ Button_Launch��5      $��시작��6(   $��377,506,10,30q�65   ���	#FFE4E4E4$��NanumGothic)�6�   $
 Hand��6�   $��24(�6�   $
��Bold"�6�   ���	#FF484848��6�   Z� 6�   �� 5   
   -   5        $ ListBox_todaysCleaners��5      $��377,95,10,99q�6]   $��NanumGothic)�6s   ���	#FFDEE6FF���	#FF464646$��48(�6�   $��SemiBold"�6�   �� 5   
   -   5        $ Label_todaysCleaners��5      $��오늘의 청소 당번��6.   $��0,47,200,510q�6B   $��NanumGothic)�6X   $��30(�6q   $
��Bold"�6   $��Right=�6�   ���	#FF323232$	��232��6�   $  ��6�   �� 5   
   -   5        $  Label_exceptionNumber_Copy��5      $'��!Github: https://github.com/jo0012��64   $��633,570,10,4q�6a   $��Right=�6w   $��NanumGothic)�6�   $��12(�6�   5      5      