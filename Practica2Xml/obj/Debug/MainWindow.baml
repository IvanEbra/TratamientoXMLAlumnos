   M S B A M L   `   `   `  ����G  CPractica2Xml, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Practica2XmlPractica2Xml  5   	       Practica2Xml.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Practica2Xml     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � .+�5
   
   � -   5         �Name$ gridInicial��5
      $
��Left=�6$   $	��140��6?   $��240,138,0,0q�6L   $	��Top=�6a   $	��296��6y   .+�5      �� -   5         ��Name$ botonResumenFaltas��5      $��Resumen Faltas��61   $
��Left=�6J   $��
173,62,0,0q�6e   $	��Top=�6y   $	��113��6�   6�   �� 5      -   5        $ botonGestionarAlumnos��5      $��Gestionar Alumnos��64   $
��Left=�6P   $��	10,62,0,0q�6k   $	��Top=�6~   $	��113��6�   6�   5      � 5   
   -   5        $ gridGestionarAlumnos��5      $
��Left=�6-   $	��401��6H   $��	10,10,0,0q�6U   $	��Top=�6h   $	��773��6�   $y�Hidden=�6�   .+�5      �� -   5        $ botonAgregarAlumno��5      $��Agregar Alumno��61   $
��Left=�6J   $��330,347,0,0q�6e   $	��Top=�6z   $	��135��6�   $��37��6�   6�   �� 5      -   5        $ botonEliminarAlumno��5      $��Eliminar Seleccionado��62   $
��Left=�6R   $��511,347,0,0q�6m   $	��Top=�6�   $	��135��6�   $��37��6�   6�   &   System.Windows.Controls.DataGrid  5      -   5          Name$ dataGridAlumnos��5      $
��Left=�60   $	��299��6K   $��	10,28,0,0q�6X   $	��Top=�6k   $	��753��6�   �� 5      -   5        $ botonVolverInicio��5      $��Volver al Inicio��60   $
��Left=�6K   $��141,347,0,0q�6f   $	��Top=�6{   $	��135��6�   $��37��6�   6�   5      � 5   
   -	   5        $ gridAgregarAlumno��5      $
��Left=�6*   $	��298��6E   $��
213,62,0,0q�6R   $	��Top=�6f   $	��323��6~   $y�Hidden=�6�   .+�5      �� -
   5        $ botonAgregar��5      $��Agregar��6+   $
��Left=�6=   $��
92,239,0,0q�6X   $	��Top=�6l   $��75��6�   6�   �� 5      -   5        $ botonVolver��5      $��Volver��6*   $
��Left=�6;   $��222,239,0,0q�6V   $	��Top=�6k   $��75��6�   6�   �� 5      -   5         ��Name$ labelId��5      $	��ID:��6%   $
��Left=�63   $��	92,57,0,0q�6N   $	��Top=�6a   �� 5      -   5         ��Name$ 	textBoxId��5      $
��Left=�6)   $��26��6D   $��
157,57,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��120��6�   �� 5      -   5        $ 
labelEmail��5      $��Email��6(   $
��Left=�68   $��
78,105,0,0q�6S   $	��Top=�6g   �� 5      -   5        $ textBoxEmail��5      $
��Left=�6,   $��25��6G   $��157,105,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��120��6�   �� 5      -   5        $ labelNombre��5      $��Nombre��6)   $
��Left=�6:   $��
62,163,0,0q�6U   $	��Top=�6i   �� 5      -   5        $ textBoxNombre��5      $
��Left=�6-   $��26��6H   $��157,163,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $	��120��6�   5      � 5   
   -   5        $ gridResumenFaltas��5      $
��Left=�6*   $	��373��6E   $��	28,28,0,0q�6R   $	��Top=�6e   $	��731��6}   $y�Hidden=�6�   .+�5      �� -   5         ��Name$ comboModulos��5      $
��Left=�6-   $��	93,10,0,0q�6H   $	��Top=�6[   $	��120��6s   $��26��6   6�   �� 5       -   5        $ lableModulos��5       $��Modulos:��6*   $
��Left=�6=   $��	10,10,0,0q�6X   $	��Top=�6k     5!      -   5        $ dataGridResumenFaltas��5!      $
��Left=�66   $	��292��6Q   $��	10,71,0,0q�6^   $	��Top=�6q   $	��711��6�   �� 5"      -   5        $ botonSerializarResultado��5"      $��Serializar Resumen��67   $
��Left=�6T   $��
277,10,0,0q�6o   $	��Top=�6�   $	��113��6�   $��26��6�   6�   �� 5#      -   5        $ botonVolvIni��5#      $��Volver��6+   $
��Left=�6<   $��
414,10,0,0q�6W   $	��Top=�6k   $	��116��6�   $��26��6�   6�   5$      5&      5'      