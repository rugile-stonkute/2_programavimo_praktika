   M S B A M L   `   `   `  ����E  A3_praktine, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:_3_praktine_3_praktine  5   	       _3_praktine.LecturerPanel   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:_3_praktine     5   	     � Title$  LecturerPanel��5   	   $	��450��6   $	��800��6,   .��5	      � .+�5
   
   �� .+�5      �� $��Pažymys��6    �� Left$ 33��6&   
 �� Top$	 235��67   �� 5      -   5         ��Name$ GradeTextBox��5      $ 93��6,   $	 239��6=    �� TextWrapping$
 Wrap=�6N   $	��120��6b    �� 	MaxLength$ 2��6n   �� 5      -   5         ��Name$ RemoveGradeButton��5      $��	Ištrinti��60   $ 76��6C   $	 294��6T   $��58��6e   $��35��6p   6|   �� 5      -   5        $��
Atžymėti��5      $	 349��6(   $	 367��6:   6K   �� 5      -   5        $��
Išsaugoti��5      $	 173��6)   $	 309��6;    J� RenderTransformOrigin$ 0.175,-0.347&�6c   5      �� 5   
   -   5        $ LogoutButton��5      $��
Atsijungti��6'   $
��Left=�6<   $��
712,24,0,0q�6W   $	��Top=�6k   6�   �� 5   
   -   5         ��Name$ UserMetadata��5      $�� ��6&   $
��Left=�61   $��	45,34,0,0q�6L   $	��Top=�6_   $	��200��6w   �� 5   
   -   5        	 ��Name$	 SubjectDropdownList��5      $
��Left=�60   $��
31,137,0,0q�6K   $	��Top=�6_   $	��167��6w   $��26��6�   �� 5   
   $��Dalykas��6   $
��Left=�6"   $��
31,106,0,0q�6=   $	��Top=�6Q   $��81��6i   �� 5   
   -   5        $	 StudentDropdownList��5      $
��Left=�60   $��
31,199,0,0q�6K   $	��Top=�6_   $	��167��6w   $��26��6�   �� 5   
   $��	Studentas��6   $
��Left=�6$   $��
31,168,0,0q�6?   $	��Top=�6S   &   System.Windows.Controls.DataGrid  5   
   -	   5        
  Name$
 Grades��5      $��354,97,34,81q�6#      SelectionMode$ Single=�6d      CanUserAddRows$ False��6{      CanUserResizeRows$ False��6�      CanUserDeleteRows$ False��6�      
IsReadOnly$
 True��6�      CanUserSortColumns$ False��6�   5      5      