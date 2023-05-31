# How the connection is executed

So, the server starts, and inmediately the port in the NetworkManager of the scene, is occupied. Once the client reach that port, the server stablished the connection, but here comes the big IF, all the parameters for the connection are valid. In this case, the client is connecting from a browser (a WebGL Unity build) and the build for the server is hosted in a VM on Google Cloud. Cool, but for it works, the Transport derived class: "Simple Web Transport", that uses the Web Secure Sockets (WSS) to communicate, have to connect with a Full-qualified Domain Name (FQDN), in other words, that server has to be a ssl certifcate, thus, a Domain Name. Addionally, the server is not working alone, its most crucial fellow is Nginx. As the server can not verify the connection properly, the Nginx has to perfoming a reverse-proxy strategy. So there is a lot of requirements for the connection to work.

## How is the timeline of the connection client->server

