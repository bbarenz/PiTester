   M S B A M L   `   `   `  ����C  ?PiTester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:PiTesterPiTester  5   	       PiTester.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:PiTester     5   	   -   5          � Title$  	Pi-Tester��5   	   $	��450��6   $	��770��6(    � 
ResizeMode$ NoResize=�64    � Icon$ pi.ico��6J   .��5	      � $��10,0,4,6q�6   $	��770��6   $	��450��6)   $��Stretch=�66   $��Stretch=�6R   $	��559��6p   $	��279��6   .+�5
   
   �� -   5         ��Name$ btn_ClearStartOver��5
      $��Clear and Start Over��6-   $
��Left=�6L   $��
614,65,0,0q�6g   $	��Top=�6{   $	��117��6�   $��34��6�   �� 5   
   -   5        $ btn_StartOverLastPos��5      $��Reset at Last Value��6/   $
��Left=�6M   $��614,117,0,0q�6h   $	��Top=�6}   $	��117��6�   $��34��6�   6�   �� 5   
   -   5         ��Name$ txt_EnterDigits��5      $
��Left=�6+   $	��104��6F   $��	33,65,0,0q�6S    �� TextWrapping$
 Wrap=�6f   $	��Top=�6z   $	��559��6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   �� 5   
   $��Enter Digits:��6   $
��Left=�6(   $��	33,39,0,0q�6C   $	��Top=�6V   �� 5   
   $��Digits Output��6   $
��Left=�6(   $��
34,174,0,0q�6C   $	��Top=�6W   �� 5   
   $��Count:��6   $
��Left=�6!   $��440,174,0,0q�6<   $	��Top=�6Q   �� 5   
   -   5         ��Name$ lbl_DigitLength��5      $��0��6)   $
��Left=�65   $��487,174,0,0q�6P   $	��Top=�6e   $
��Bold"�6}   �� 5   
   -   5        $ lbl_OutputInfo��5      $��Nothing��6(   $��	34,10,0,0q�6:   $	��Top=�6M    J� RenderTransformOrigin$ -5.84,-3.001&�6e   $��16(�6�   $��Lucida Bright)�6�   $
��Bold"�6�   $
��Left=�6�   $	��558��6�   ���	#FFF90F0F��6�   Z� 6  �� 5   
   -   5        	 ��Name$	 spnl_SelectDigits��5      $
��Left=�60   $	��205��6K   $��610,200,0,0q�6X   $	��Top=�6m   $	��121��6�   .+�5      �� $��Select Digits:��6   $
��Left=�6-   $	��Top=�6H   $��33��6`   	� 5      -   5        
 	�Name$
 rbtn_100Digits��5      $��
100 Digits��62   $
��Left=�6G   $��5,0,5,1q�6b   $	��Top=�6s   $ 0.569,1.288&�6�    d� 	IsChecked$
 TrueY�6�   6�   	� 5      -	   5        $
 rbtn_200Digits��5      $��
200 Digits��62   $
��Left=�6G   $��5,1,5,1q�6b   $	��Top=�6s   6�   	� 5      -
   5        $
 rbtn_1000Digits��5      $��1000 Digits��63   $
��Left=�6I   $��5,1,5,5q�6d   $	��Top=�6u   6�   �� 5      -   5        $ btn_ClearHighSCore��5      $��Clear High Score��61   $��5,5,5,5q�6L   6]   5      �� 5   
   $��1q�6   ���	#FFB9B7B7$��33,200,178,45q�6=   $	��559��6T   ._�5      �� -   5         ��Name$ txtb_Output��5      $��
-1,-1,-1,0q�6-   $
��Wrap=�6A   $��	TextBlock��6U   $	��Top=�6f   $	��224��6~   $	��559��6�   $
��Auto=�6�   $
��Auto=�6�   
��� � �6�   5      �� 5   
   -   5        $ lbl_HighScore��5      $��High Score:��6'   $��
597,11,0,0q�6=   $	��Top=�6Q   $ -5.84,-3.001&�6i   $��14(�6�   $��Lucida Bright)�6�   $
��Bold"�6�   $
��Left=�6�   $	��118��6�   ���	#FF07823C��6�   Z� 6  5       5#      