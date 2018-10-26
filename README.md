# ProductWeb Service | RestApi

```
page => numero de pagina.
size => tamaño de elementos.
GET | https://localhost:44326/api/producto?page=1&size=2
POST | https://localhost:44326/api/producto
Ejemplo =>
{
	"nombre": "Disfraz",
	"correo": "Disfraz@correo.com",
	"pais":  "Disfraz",
	"precio": 12000,
	"undDisponibles": 20,
	"undVendidas": 10,
	"descripcion": "Las mejores Disfraz de colombia"
}

PUT | DELETE => https://localhost:44326/api/producto/{id}

```
