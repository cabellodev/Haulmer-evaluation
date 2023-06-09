# Haulmer-evaluation

De comienzo , para poder tener una buena experiencia en la ejecución del programa se necesita tener en consideración:

1. Clonar este repositorio o bajarlo directamente para su importación.
2. Utilizar un IDE o entorno ( preferentemente Microsoft Visual Studio ) 
3. Debido a que es una demostración de buenas prácticas y simplicidad , se cuenta con un archivo DataUsers.json (en la raiz del proyecto)  que será nuestra base de datos de prueba. Con esto simplificaremos la manera de ejecutar el programa. NO HAY QUE MOVERLO DE SU UBICACION.
4. Utilizar la coleccion API Postman para realizar las solicitudes correspondientes. El archivo es HAULMER-SOLUTION.postman_collection.json


 # 1 - POSTMAN: desde Postman se cuentan con los 4 endpoints solicitados . 

 1. (GET) /api/User/listaUsuarios     ----> lista de usuarios   
 2. (POST)/api/User/guardarUsuario    ----> guardar un usuario 
 3. (POST)/api/Encrypted/encrypt      ----> encriptado de texto plano 
 4. (POST)/api/Encrypted/decrypt      ----> desencriptado del base 64 devuelvo en endpoint 3 

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
 
  **NOTA DE ACCIÓN: Se decidió por demostrar la ejecucion del programa a través de una base de datos simple ,realizada con un archivo de texto JSON , esto especialmente para darle prioridad a la demostración del uso de .NET CORE  y no ahondar en configuraciones extras de gestores de bases de datos por parte de los evaluadores ( mayor comodidad). Se sabe que en casos  reales se puede disponer de un ORM como EntityFramework actuando como capa de abstracción de datos aprovechando las comodas bondades de la programación orientada a objetos y el uso de SQL server , pero solo para este ejemplo se pretende hacer más agil la demostración del uso de .NET  a través del almacenamiento y lectura de un archivo JSON.** 
  
  
  # 4 IMPLEMENTACIÓN DE ENCRIPTADO Y DESENCRIPTADO 
   Para realizar ambas acciones se selecciono el algoritmo llamado MD5 , que tiene amplio uso por ser sencillo y rápido . Ideal para    demostraciones como estás . No se recomienda para casos mas serios donde se necesite mayor seguridad. 
   
  # 5 DEMOSTRACIONES ANEXAS
    Puede ocupar swagger (que viene  integrado con .NET core) para poder realizar las operaciones con los endpoint creados en el proyecto. 
    
  # EVIDENCIA DE EJECUCIÓN ( FOTOGRAFIAS ) 
