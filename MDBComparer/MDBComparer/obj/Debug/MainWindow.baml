   M S B A M L   `   `   `  ����  MDBComparer    MDBComparer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6F     � Title$  MDB Comparer��5   	   $	��350��6   $	��950��6+    � 	Resources 5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5         InputFileTextBox �� 
TargetType �� 	Resources  Key j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual �� Triggers	 P� Property
 �� Empty P� Value �� Property  CueBannerBrush �� Value��5      %E  &	        7  7  �� 5   
   6sys&clr-namespace:System;assembly=mscorlib     6   " ��6\    5	      ��!� 5
      CueBannerBrush $
 Left=�65   $ Center=�6G   $
 None=�6[    5      �� 5      $"��Click here to select file...��6    
�������6G   5      5       5      P� 5      	 � ��# Z
 6*   . �5      ��  � ��8   63   5      P� 5      	 � �� 6*   Z� . �5      ��  � ��8  63   5      P� 5      	 �@J�IsKeyboardFocused . . �5      ��  � ��
 �����63   5      5      5      .��5      � -   5         �Name$ MainGrid��5      ��.  J� RenderTransformOrigin$ 	0.497,0.5&�6B    � ColumnDefinitions 5   
   �� 5       $
��0.5* �6   �� 5!      $
��0.5* �6   �� 5"      $	��100 �6    � RowDefinitions 5$   
   �� 5%      �� 5&      $��50 �6   .+�5(   
   �� -   5         ��Name$ 
FilePath_L��5(      #��[  6&    �� TextWrapping$
 Wrap=�6P   $	��Top=�6d   $��1��6�   $��0,20,5,0q�6�   �� 5)   
   -   5        $ 
FilePath_R��5)      #��[  6&   $
 Wrap=�6P   $	��Top=�6d   $��1��6�   $��1��6�   $��0,20,5,0q�6�   �� 5*   
   -   5         ��Name$ CloseButton��5*      $��Close��6&   $ -1.36,4.136&�6P   $��1��6t   $	��Top=�6�   $��Center=�6�   $��2��6�   $��0,20,5,0q�6�   �� 5+   
   $��Compare database��6   $
��Left=�6+   $��1��6F   $	��Top=�6S   $��29��6k   �� 5,   
   $��1��6   $
��Left=�6    $��1��6;   $	��Top=�6H   $ 0.079,-0.154&�6`   $��0,1,0,0q�6�   .��5-      �� $
��Wrap=�6   $��with database��6,   5.      �� 5/   
   $��3��6   .��50   
   �� -   5         ��Name$ TextBlockOut��50      $��3��6*   $ 0.5,0.5&�6>   $	��200��6^   $	��800��6n   $��11(�6}   $��Courier New)�6�   $��CharacterEllipsis=�6�    �� Padding$ 10,5,0,0q�6�   z�51      V� 52      .~�53      �� �� 54      �� 55       �� Angle$ -0.26Q�6&   T� 56      57      59      5:      5;      5=      