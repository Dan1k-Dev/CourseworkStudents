   M S B A M L   `   `   `  ����  Study_Navigation!    Study_Navigation.MainWindow   5   	   DmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   [ WMahApps.Metro.IconPacks.Material, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  6P   -   5          � Title$   ��5   	   $	��450��6   $	��380��6    � 
ResizeMode$ NoResize=�5	   	    � WindowStyle$ SingleBorderWindow=�5
   	   
������  � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $	��220 �6    �� 5      $��* �6    .+�5      ��  �� CornerRadius$ 0��6   $��2��6&   
�������5      �� 5      $��Center=�6   .+�5      �� $��Авторизация��6   $��Light"�5      $��
gotham pro)�5      $��35(�5      
���   �$��Center=�5      5      �� 5       $��1��6   .+�5!      ��  �� Orientation$ 
Horizontal=�6   .+�5"      �� -   5         ��Name$ 
usernameTb��5#      $��
gotham pro)�5"      $��Light"�5$      $��
Логин��5%      $��20(�5&      $��Center=�5'      
���   �
������ $��0q�5*      $	��235��5+      $
��Left=�5,       J� Opacity$	 0.9Q�5-      $��25��5.      $��63,0,0,0q�5/      50      .  (MahApps.Metro.IconPacks.PackIconMaterial  52      -   5        $��AccountIcon��57   1   E AControlzEx, Version=3.0.2.4, Culture=neutral, PublicKeyToken=null�  �ControlzEx.PackIconBase`1[[MahApps.Metro.IconPacks.PackIconMaterialKind, MahApps.Metro.IconPacks.Material, Version=2.3.0.4, Culture=neutral, PublicKeyToken=null]]	   Kind$	 Account=�52   1   $��Center=�53   1   $��Center=�54   1   
���   �$	 0.9Q�56   1   57   1   58      �� 5:      -   5        
 ��Name$
 UsernameBorder��5>      $	��250��5:      $��2��5;      
���   �$	 0.8Q�5=      5>      �� 5@      $ 
Horizontal=�6   $��0,20,0,0q�66   .+�5A      G� -   5         G�Name$ 
passwordTb��5B   "   $��	helvetica)�5A   "   $��Light"�5C      $��20(�5D      
���   �
������  G� Password$ Пароль��5G      $��0q�5H      $	��235��5I      $
��Left=�5J      $��Center=�5K      $	 0.9Q�5L      $��25��5M      $��63,0,0,0q�5N      5O        5Q      -   5        $��PasswordIcon��5V   1   $	 TextboxPassword=�5Q   1   $��Center=�5R   1   $��Center=�5S   1   
���   �$	 0.9Q�5U   1   5V   1   5X      �� 5Z      -   5        $
 PasswordBorder��5^      $	��250��5Z      $��2��5[      
���   �$	 0.8Q�5]      5^      �� 5`      $ 
Horizontal=�6   $��0,20,0,0q�5a      .+�5c      �� -   5        $	��100��5c      $��40��6)   $��
ВОЙТИ��5d      $��	60,0,50,0q�5e         ButtonStyle#��[  5g      �� 5i      -	   5        $	��109��5i      $��40��5j      $��РЕГИСТРАЦИЯ��5k      #��[  5l      6B   5m      �� 5o      $ 
Horizontal=�6   $��
39,10,38,0q�66    J� RenderTransformOrigin$ 0.5,0.5&�6J   z�5p      V� 5q      .~�5r      �� �� 5s      �� 5t       �� Angle$ 0.076Q�6.   T� 5u      5v      .+�5x      �� -
   5         ��Name$  ExceptionOfLoginOrPassword��5      $6��0Неверный логин или пароль!��5x      $	��210��5y      $��30��5z      $��
gotham pro)�5{      $��13(�5|      $��Center=�5}      $��Center=�5~      $y�Hidden=�5�      
���  ��5�      5�      5�      5�      5�      5�      