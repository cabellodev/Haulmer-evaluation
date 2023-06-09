# Haulmer-evaluation

De comienzo , para poder tener una buena experiencia en la ejecución del programa se necesita tener en consideración:

- Clonar este repositorio o bajarlo directamente para su importación.
- Utilizar un IDE o entorno ( preferentemente Microsoft Visual Studio ) 
- Dentro del IDE  , se puede abrir el archivo "solution.sln" dentro de la carpeta "solution".
- Debido a que es una demostración de buenas prácticas y simplicidad , se cuenta con un archivo UsersData.json (en la raiz del proyecto)  que será nuestra base de datos de prueba. Con esto simplificaremos la manera de ejecutar el programa. NO HAY QUE MOVERLO DE SU UBICACION.
- Importar la coleccion API Postman para realizar las solicitudes correspondientes. El archivo es HAULMER-SOLUTION.postman_collection.json



 # 1 - POSTMAN: 
 
 Desde Postman se cuentan con los 4 endpoints solicitados . 

 1. (GET) /api/User/listaUsuarios     ----> lista de usuarios   
 2. (POST)/api/User/guardarUsuario    ----> guardar un usuario 
 3. (POST)/api/Encrypted/encrypt      ----> encriptado de texto plano 
 4. (POST)/api/Encrypted/decrypt      ----> desencriptado del base 64 devuelto en endpoint 3. 

 **NOTA DE ACCIÓN :  se determinó el uso de rutas dinámicas , para evitar eventuales ambiguedades o conflictos al acceder a estos endpoint para su consumo.** 

# 2 -CONVENSIONES 
  Se utilizaron convensiones de buenas prácticas a la hora de poder llevar a cabo cada acción . La estructura del programa consiste de : 
  - 2 controladores (para usuarios y  encriptado ) 
  - Uso de interfaces ( usuarios - desencriptado)
  - 2 Capas de servicios ( para usuarios y encriptado) .  Posteriormente en inyección de dependencias para uso en controladores.
  - 1 modelo para usuario (molde para almacenamiento en la base)  
  - Objetos DTO para ciertas acciones y orden.
  - Se siguio una convensión : 
    Clases --> PascalCase        |      Metodos ,Variables -->camelCase 
    
    **NOTA DE ACCIÓN :  se tomo rigurosidad en la decisión de aplicar todas las buenas prácticas posibles , esto difiere dependiendo de equipo desarrollador , pero se respetaron las convensiones más utilizadas para llevar un código limpio y entendible para el programador .**
    
    
 # 3. BASES DE DATOS 
 
 Para el almacenamiento se dispone de un archivo JSON, que servirá como simulador del gestor , devolviendo y escribiendo los datos  .
 
 
 <img src="https://github.com/cabellodev/Haulmer-evaluation/blob/master/capturas/FOTO-BASE%20DE%20DATOS%20USUARIOS.png" width="400" height="400">
 
 
  **NOTA DE ACCIÓN: Se decidió por demostrar la ejecucion del programa a través de una base de datos simple ,realizada con un archivo de texto JSON , esto especialmente para darle prioridad a la demostración del uso de .NET CORE  y no ahondar en configuraciones extras de gestores de bases de datos por parte de los evaluadores ( mayor comodidad). Se sabe que en casos  reales se puede disponer de un ORM como EntityFramework actuando como capa de abstracción de datos aprovechando las comodas bondades de la programación orientada a objetos y el uso de SQL server , pero solo para este ejemplo se pretende hacer más agil la demostración del uso de .NET  a través del almacenamiento y lectura de un archivo JSON.** 
  
  # 4 SERVICIOS 
   La escencia del programa esta dentro de la capa de servicios. De esta manera, a partir de inyección de depencias podemos acceder a estos servicios en cualquier lugar de la aplicación , utilizando sus funciones principales para interactuar con la base de datos. De esta manera manera tenemos mucho mas covertura y más organización de nuestras acciones.
   
   <img src="https://github.com/cabellodev/Haulmer-evaluation/blob/master/capturas/SERVICIOS%20-%20ENCRIPTACIO%CC%81N.png" width="400" height="320">
 
  
  # 5 IMPLEMENTACIÓN DE ENCRIPTADO Y DESENCRIPTADO 
   Para realizar ambas acciones se seleccionó el algoritmo llamado MD5 , que tiene amplio uso por ser sencillo y rápido . Ideal para    demostraciones como estás . No se recomienda para casos más serios donde se necesite mayor seguridad. 
   
  # 6 DEMOSTRACIONES ANEXAS
    Puede ocupar swagger (que viene  integrado con .NET core) para poder realizar las operaciones con los endpoint creados en el proyecto. 
    
  # EVIDENCIA DE EJECUCIÓN ( FOTOGRAFÍAS ) 
  
  A modo de evidencia se da a conocer las siguientes acciones (USUARIOS) : 
  
  - Se crea el usuario Pablo Cespedes con todo sus atributos . Luego al ejecutar la petición POST , el usuario en cuestión queda registrado en la base de datos, donde la API devuelve : mensaje , estado (éxito ) , datos ( no devuelve ) . 

 <img src="https://github.com/cabellodev/Haulmer-evaluation/blob/master/capturas/CREAR%20USUARIO.png" width="800" height="600">
 
 
 -Luego se comprueba su existencia ejecutando Listar usuarios , y se corrobora que el usuario esta registrado en la lista de usuarios:
  

 <img src="https://github.com/cabellodev/Haulmer-evaluation/blob/master/capturas/LISTAR%20CON%20NUEVO%20USUARIO.png" width="800" height="600">
 
 
 **NOTA : Dentro del modelo FechaCreacion y telefono son parametros libres . FechaCreacion se asigna internamente al registrar.** 
 
 Por otro lado , ahora hacemos evidencia de las encriptaciones con MD5 . Le enviaremos a la API un texto para que lo pueda encriptar. 
 
 <img src="https://github.com/cabellodev/Haulmer-evaluation/blob/master/capturas/ENCRIPTACION.png" width="800" height="600">
 
 Se aprecia que se obtiene el valor en base 64 equivalente al texto enviado encriptado.
 
 - Por ultimo , con la respuesta entregada en base 64 de la petición anterior , se procede a desencriptar : 
 
 <img src="https://github.com/cabellodev/Haulmer-evaluation/blob/master/capturas/DESCRIPTACIO%CC%81N.png" width="800" height="600">

  Por lo que se puede apreciar que nuevamente nos devuelve el valor original , es decir , Haulmer empresas. Lo ha desencriptado. 
  
  # CONCLUSIONES 
  Todas las decisiones tomadas en este proyecto fueron considerando los principios mas importantes de la programación en .NET , en especial el dominio de diferentes definiciones,convenciones,programación orientada a objetos e inyección de dependecias . 
