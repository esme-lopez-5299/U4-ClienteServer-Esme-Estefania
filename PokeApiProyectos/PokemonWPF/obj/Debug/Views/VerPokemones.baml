   M S B A M L   `   `   `  ����E  APokemonWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:PokemonWPF.ViewsPokemonWPF.Views  5   	   =#clr-namespace:PokemonWPF.ViewModelsPokemonWPF.ViewModels  5   	   #    PokemonWPF.Views.VerPokemones   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:PokemonWPF.Views     5   	   2vm#clr-namespace:PokemonWPF.ViewModels     5   	     � Title$  VerPokemones��5	   	   $	��800��6   $	��800��6+    � WindowStartupLocation$ CenterScreen=�67    � WindowState$ 	Maximized=�6\    � DataContext 5
      ,   &PokemonWPF.ViewModels.PokemonViewModel  5   
   6    .��5      � .+�5      ]� .+�5      � $	��Top=�6   ���#ffea00 � ColumnDefinitions 5      �� 5      6)   �� 5      $��3* �6'   65   �� 5      6)   .+�5      �� $��
20,10,0,10q�6   $��/Images/logo.png��6,   $	��160��6F   6T   �� 5      $��1��6   ���#00296b$
��Bold"�6B   $��Right=�6T   $��45��6p   $��35(�6|   $��Segoe UI)�6�    �� TextAlignment$ Center=�6�   $	��795��6�   Find your Pokemon6�   5      � 5      $��	0,10,0,10q�6   $	��Top=�6+   $��Right=�6@   .+�5      � .+�5      �� -   5        $��mybox��5      
�������$��	10,0,10,0q�6?    �� SelectedValuePath$
 name��6�   $	��140��6�    �� SelectedValue 6S   �� *BusquedaObj.habilidadBuscada+ �� Mode$ TwoWay=���6�   �� *Habilidades.results+��5      �� 5      .R�5   "   �� ��6/   �� *name+6J   5       5"      �� 5#      $��Center=�6    $��Center=�6;   $
��Bold"�6X   $��14(�6j   $��--Abilities--��6y   	 J� IsHitTestVisible	 .  ��5$      �� 5%      
 �� 
TargetType"
 ��6$   .�5&   "   ��  �� Property � y� �� Value$ Hidden=�6?    �� Triggers 5'   "   �� 5(   &    �� Binding 62   ��  �� ElementName$ mybox�� �� Path$ SelectedItem� �� Value 6j   Z� .a�5)   *   ��  � y�$ Visible=�6G   5*   '   5,      5.      5/      � 51      .+�52      �� -   5        $��
myboxTypes��52      $��	10,0,10,0q�61   $
 name��6�   $	��140��6�    6D   �� *BusquedaObj.tipoBuscado+$ TwoWay=���6�   �� *Tipos.results+��53      �� 54      .R�55   "   �� ��6,   �� *name+6D   56      58      �� 59      $��Center=�6    $��Center=�6;   $
��Bold"�6X   $��14(�6j   $��	--Types--��6y   	 .  ��5:      �� 5;      "
 ��6$   .�5<   "   ��  � y�$ Hidden=�6?    5=   "   �� 5>   &    62   �� $ 
myboxTypes��$ SelectedItem� 6o   Z� .a�5?   *   ��  � y�$ Visible=�6G   5@   '   5B      5D      5E      �� 5F      $��	10,0,10,0q�6   $	��140��6.   $��18(�6:   ��6H   �� *BusquedaObj.nombreBuscado+.��6s   ��5G      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5H   5   �� 6   6sys&clr-namespace:System;assembly=mscorlib     65   "
 ��6     �� 	Resources 5I         CueBannerBrush j� 
AlignmentX j� 
AlignmentY j� Stretch !� Visual��%�   &	        !� 5J   "   $
 Left=�6E   $ Center=�6W   $
 None=�6k    5K   &   �� 5L   *   $��Search by name��60   
�������6I   5N   #   5O       5P      P� 5Q   "    P� Property � �� �� Empty P� Value# Z 6:   . �5R   &   ��  � ��# [  6C   5S   #   P� 5T   "    � �� 6:   Z� . �5U   &   ��  � ��# [  6C   5V   #   P� 5W   "    �@J�IsKeyboardFocused . . �5X   &   ��  � ��
 �����6C   5Y   #   5[      .��5\   %   5]      �� 5^       �� CornerRadius$ 8��6   ���#f6443e$��	10,0,10,0q�6;   ._�5_      �� -   5         ��Name$ btnReset��5_   �   
������ 
�������
������ $
��Bold"�6�   $
��20,0q�6�   $��18(�6�   ��6   �� *ResetCommand+.��6�   Reset6�   5`      �� 5a      $ 8��6   ���#0094ff$��	10,0,10,0q�6;   ._�5b      �� -   5        $ 	btnSearch��5b   �   $��18(�6   
������ 
������ $
��Bold"�6Z   
�������$
��18,0q�6   ��6�   �� *HacerBusquedaCommand+��6�   �� *BusquedaObj+.��6�   Search6�   5c      5d      �� 5e      $��	20,10,0,0q�6   $��Visible=�6/   .��5f      �� .+�5g      �� $��80,10,80,10q�69   $
��Bold"�6N   $��20(�6`   ��6    �� *	Mensaje+6p   �� 5h      -   5        $��scroll��5h   #   $��Hidden=�61   .��5i      �� ��6#   �� *	Pokemones+��5j      �� 5k      .R�5l   "   A�  A� Columns$ 6��6.    K� IsItemsHost . 6O   5m      ��5o      �� 5p      .R�5q   "   �� $��20q�6*   ���#ffea00$��4q�6L   ._�5r   &   � $��Center=�6,    � RowDefinitions 5s   .   �� 5t   2   6B   �� 5u   2   $	��.5* �6@   6O   �� 5v   2   6B   .+�5x   .   �� $��Uniform=�65   $��Center=�6G   $	��170��6e   ��5y   2   �� 5z   6   $1 +sprites.other.OfficialArtwork.front_default�6>    �� TargetNullValue 5{   :   ��5|   >   /Images/logo.png��6\   5~   7   5�   /   �� 5�   .   $��1��69   $��Center=�6F     K� Capitals$  AllSmallCaps=�6c   
���   �$��Brandon Grotesque)�5�   ,   $��20(�6K   ��5�   �   �� *name+5�   +   �� 5�   .   $��0,0,0,10q�65   $��2��6G   ���#0094ff$ 8��6j   $��40��6{   $	��100��6�   ._�5�   2   �� 
�������$
��Bold"�6L   
������ 
������ ��6�   �� *DataContext.VerDetalleCommand+$ scroll����5�   a   �� *name+.��6�   
Ver más6�   5�   /   5�   +   5�   #   5�      5�      5�      5�      5�      5�      (   "PokemonWPF.Views.VerDetallePokemon  5�   
   ��5�      �� 5�      "
 >�6   .�5�      ��  � y�$ Hidden=�63   6D    5�      �� 5�      !   PokemonWPF.ViewModels.Modal!   
VerDetalle# Z! 6G    6&   �� *ModalVisible+.a�5�      ��  � y�$ Visible=�6;   6M   5�      5�      5�      5�      5�      