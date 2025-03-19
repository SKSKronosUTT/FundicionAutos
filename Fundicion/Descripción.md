# Fundición de carros 
Una empresa desea llevar el control de vehículos que se van a fundir,
para lo cual tiene **5 pilas de 10 vehículos** cada una, 
identificados por nombres de acuerdo a una clasificación  _(compactos, camionetas, vagonetas, camiones, autobuses)_,
y  cada vehículo **tiene también un código de identificación y una  descripción.**
La empresa desea conocer el **nombre** de cada vehículo que  ha pasado al horno de fundición, para **darlo de baja**, de una  pila de vehículos que haya seleccionado. Los vehículos dados  de baja se registran para generar un reporte al final del día.


Las opciones del sistema con sus respectivas condiciones y/o restricciones, son las siguientes:
Opción Condiciones y/o restricciones
1. **Ingresar auto:** Solicitar al usuario la clasificación del vehículo (submenú) y verificar que haya espacio disponible, en caso de haber espacio, agregar del auto, el código de identificación y la descripción, después, desplegar el nombre de la clasificación y el número que ocupa en la pila. Después de agregar el auto, dar la opción al usuario de repetir el proceso. En caso de no haber espacio en la clasificación elegida, enviar el mensaje correspondiente y regresar al menú.

2. **Retirar auto:** Solicitar al usuario la clasificación del cual se retirará el auto (submenú). Verificar que no se encuentre vacía esa pila elegida. En caso de retirar un auto, desplegar sus datos y el número que ocupaba en la pila para solicitar confirmación del usuario. Después, dar la opción al usuario de repetir el proceso.

3. **Autos por clasificación:** Solicitar al usuario la clasificación del cual desea ver la información de los autos
(submenú). En caso de que tenga autos, desplegar los datos de cada vehículo, en
columnas.

4. **Autos totales:** Desplegar el total de autos por clasificación y el total general.
5. **Autos retirados:** Solicitar al usuario la clasificación del cual se desea ver la información de los autos retirados (submenú). Mostrar la información en columnas.

6. **Salir:** Será la única opción para salir del programa.