## Instrucciones

### Las siguientes dependencias son necesarias para implementar Memcached como cache

- EnyimMemcachedCore

### Instalar Memcached en local:

- Instalar docker en windows https://docs.docker.com/desktop/windows/install/
- Ejecutar desde un powershell **docker run --name memcached_prueba5   -e MEMCACHED_USERNAME=USER  -e MEMCACHED_PASSWORD=PASSWORD -d -p 5006:11211  bitnami/memcached:latest
** . Si todo fue ok, se deberá devolver un container id como   por ejemplo **2dabade3f5888e63e94cb692faa7fe925072ddb5e1517f1d3ffdfb3faf98dc24**  
