   M S B A M L   `   `   `  ����>  :sql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:sqlsql  5   	       sql.AddPreparation   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:sql     5   	     � Title$  AddPreparation��5   	   $	��550��5	   	   $	��750��5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � AllowsTransparency . .��5      � ���#23262b.+�5   
   �� $��Center=�6   $	��Top=�6-   $	��100��6E   $	��750��6R   ���#2e333a6u   �� 5   
   $L��FДобавление - редактирование препарата��6   $
��Left=�6@   $��	34,21,0,0q�6[   $	��Top=�6n   $��Times New Roman)�6�   $��36(�6�   ���#FFFFFF6�   �� 5   
   $!��Производитель:��6   $
��Left=�6)   $��
70,115,0,0q�6D   $	��Top=�6X   $��Times New Roman)�6p   $��35(�6�   ���#FFFFFF6�   �� 5   
   $��Форма:��6   $
��Left=�6!   $��197,180,0,0q�6<   $	��Top=�6Q   $��Times New Roman)�6i   $��35(�6�   ���#FFFFFF6�   �� 5   
   $*��$Название препарата:��6   $
��Left=�6.   $��
-1,246,0,0q�6I   $	��Top=�6]   $��Times New Roman)�6u   $��35(�6�   ���#FFFFFF6�   �� 5   
   $��Цена(руб.):��6   $
��Left=�6&   $��137,315,0,0q�6A   $	��Top=�6V   $��Times New Roman)�6n   $��35(�6�   ���#FFFFFF6�   �� 5   
   $��Количество:��6   $
��Left=�6&   $��123,382,0,0q�6A   $	��Top=�6V   $��Times New Roman)�6n   $��35(�6�   ���#FFFFFF6�   �� 5   
   -   5         ��Name$ producer��5      $
��Left=�6?   $��331,115,0,0q�6Z    �� TextWrapping$ NoWrap=�6o   $	��Top=�6�   $	��400��6�   ���#2e333a$��50��6�   $��30(�6�    �� TextAlignment$ Center=�6�   ���#FFFFFF��6$   �� *
producer+6�   �� 5   
   -   5        $
 form��5      $
��Left=�6>   $��331,180,0,0q�6Y   $	��Top=�6n   $	��400��6�   ���#2e333a$��50��6�   $��30(�6�   ���#FFFFFF$ Center=�6�   ��6    �� *release_form+6�   �� 5   
   -   5        $
 name��5      $
��Left=�6;   $��331,246,0,0q�6V   $	��Top=�6k   $	��400��6�   ���#2e333a$��50��6�   $��30(�6�   ���#FFFFFF$ Center=�6�   ��6    �� *	drug_name+6�   �� 5   
   -   5        $ price��5      $
��Left=�68   $��331,313,0,0q�6S   $	��Top=�6h   $	��400��6�   ���#2e333a$��50��6�   $��30(�6�   ���#FFFFFF$ Center=�6�   ��6!   �� *price+6�   �� 5   
   -   5        $ amount��5      $
��Left=�6:   $��331,380,0,0q�6U   $	��Top=�6j   $	��400��6�   ���#2e333a$��50��6�   $��30(�6�   ���#FFFFFF$ Center=�6�   ��6"   �� *amount+6�   �� 5   
   -   5           CloseBtnStyle#��[  5      68   �� 5   
   -   5        $��Сохранить��5      $��Center=�6%   $��	0,469,0,0q�6B   $	��Top=�6U   ���#2e333a���#FFFFFF$��36(�6�   $��Times New Roman)�6�   $	��350��6�   $��50��6�   6�   5       5!      