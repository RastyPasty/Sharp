   M S B A M L   `   `   `  ����   MDBComparer    MDBComparer.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  MDB Comparer��$	��350��$	��950�� � 	Resources O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem    InputFileTextBox �� 
TargetType �� 	Resources  Key j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual �� Triggers	 P� Property
 �� Empty P� Value �� Property  CueBannerBrush �� Value��%g  &	        7  7  �� 6sys&clr-namespace:System;assembly=mscorlib     " �� ��!� CueBannerBrush $
 Left=�$ Center=�$
 None=� �� $"��Click here to select file...��
������� P� 	 � ��# Z
 . ���  � ��8   P� 	 � �� Z� . ���  � ��8  P� 	 �@J�IsKeyboardFocused . . ���  � ��
 �����.��� -    �Name$ MainGrid����.  J� RenderTransformOrigin$ 	0.497,0.5&� � ColumnDefinitions �� $
��0.5* ��� $
��0.5* ��� $	��100 � � RowDefinitions �� �� $��50 �.+��� -    ��Name$ 
FilePath_L��#��[   �� TextWrapping$
 Wrap=�$	��Top=�$��1��$��0,20,5,0q��� -   $ 
FilePath_R��#��[  $
 Wrap=�$	��Top=�$��1��$��1��$��0,20,5,0q��� -    ��Name$ CloseButton��$��Close��$ -1.36,4.136&�$��1��$	��Top=�$��Center=�$��2��$��0,20,5,0q��� $��Compare database��$
��Left=�$��1��$	��Top=�$��29���� $��1��$
��Left=�$��1��$	��Top=�$ 0.079,-0.154&�$��0,1,0,0q�.���� $
��Wrap=�$��with database���� $��3��.���� -    ��Name$ TextBlockOut��$��3��$ 0.5,0.5&�$	��200��$	��800��$��11(�$��Courier New)�$��CharacterEllipsis=� �� Padding$ 10,5,0,0q�z�V� .~��� �� ��  �� Angle$ -0.26Q�T� 