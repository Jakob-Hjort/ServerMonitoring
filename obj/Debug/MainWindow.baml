   M S B A M L   `   `   `  ����G  CModerndesign, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ModerndesignModerndesign  5   	   I)clr-namespace:Moderndesign.MVVM.ViewModelModerndesign.MVVM.ViewModel  5   	       Moderndesign.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Moderndesign     5   	   ?	viewModel)clr-namespace:Moderndesign.MVVM.ViewModel     5   	   $	��600��5	   	   $	��920��6     � WindowStyle$
  None=�5
   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � DataContext 5      /  )Moderndesign.MVVM.ViewModel.MainViewModel  5   
   .��5      ��  �� CornerRadius$ 20��6   ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,2&�63   .��5      �  � Color$ #f7d0cb��6    � Offset$	 0.0Q�6/   � 5      $ #bf9b30��6   $ 1Q�6/   5      ._�5   
   � 	 � ColumnDefinitions	 5      �� 5      $	��200 �6#   �� 5      
 � RowDefinitions
 5!      �� 5"      $��75 �6    �� 5#      .+�5&      �� $��Dansk Vinimport��6   $��Center=�5'      $
��Left=�5(      ���#AA6C39$��22(�5*      $��20,0,0,0q�5+      �� 5-      $��1��6   .+�5/      	� $��Nyheder��6   $��50��50      ���#000000$��14(�52         MenuButtonTheme#��[  53       d� 	IsChecked$
 TrueY�54      ��55      �� *HomeViewCommand+	� 57      $��Lager��6   $��50��58      ���#000000$��14(�5:      #��[  5;      ��5<      �� *LoadViewCommand+5>      �� 5@      $	��250��6   $��40��5A      $��Center=�5B      $
��Left=�5C      $��5q�5D      $��1��5E        ModernTextBox#��[ 5F      �� 5H      $��1��6   $��1��5I      $��10q�5J      ��5K      �� *CurrentView+5L      5N      5O      