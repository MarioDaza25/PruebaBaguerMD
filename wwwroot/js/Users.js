// Función para realizar petición fetch al servidor y manejar la respuesta
async function fetchData(config) {
  try {
    const response = await fetch(`http://localhost:5283/PruebaBaguer/Usuario`, config);
    const data = await response.json();
    return data;
  } catch (error) {
    console.error("Error en la petición", error);
  }
}  

/* ----------------------------------------------AGREGAR----------------------------------------*/
// Función para agregar un nuevo usuario
function agregarUsuario() {
  // Obtener los valores de los campos del formulario
  const nombre = document.getElementById("nombre").value;
  const usuario = document.getElementById("usuario").value; 
  const correo = document.getElementById("correo").value;

  // Crea un objeto con los datos del nuevo usuario
  const userData = {
    nombre: nombre,
    nombreUsuario: usuario,
    correo: correo,
    "rolid": 1
  }; 
  
  // Convierte los datos del usuario a formato JSON
  const jsonData = JSON.stringify(userData);

  // Configuración para la petición fetch de tipo POST
  const config = {
    method: "POST",
    headers: {"Content-Type": "application/json"},
    body: jsonData
  };
  
  // Realiza la petición fetch para agregar el nuevo usuario y recarga la página después
  fetchData(config).then(() => window.location.reload());
}

/* ----------------------------------------------EDITAR----------------------------------------*/
// Función para agregar un nuevo usuario



/* ----------------------------------------------ELIMINAR----------------------------------------*/
// Función para eliminar un usuario del servidor
function eliminarUsuario(id) {
  // Realiza una petición fetch de tipo DELETE para eliminar el usuario con el ID especificado
  fetch(`http://localhost:5283/PruebaBaguer/Usuario/${id}`, {
    method: 'DELETE'
  }).then(() => window.location.reload());
}

/* ----------------------------------------------LISTAR----------------------------------------*/

// Función que se ejecuta cuando se carga el DOM, para listar los usuarios
document.addEventListener('DOMContentLoaded', async function() {
  // Configuración para la petición fetch de tipo GET
  const config = { method: "GET"};
  
  // Realiza la petición fetch para obtener los datos de los usuarios
  const data = await fetchData(config);

  // Verifica si los datos son un array o un solo objeto y los convierte en un array si es necesario
  const dataArray = Array.isArray(data) ? data : [data];
  
  // Itera sobre el array de datos y genera el HTML correspondiente para cada usuario
  dataArray.forEach((usuario) => {
      const usuarioHTML = `
          <tr>
              <th scope="row">${usuario.id}</th>
              <td>${usuario.nombre}</td>
              <td>${usuario.correo}</td>
              <td>${usuario.nombreUsuario}</td>
              <td><a onclick="editarUsuario(${usuario.id})" href="#"><img class="img-crud" src="../images/icons8-editar.svg" alt=""></td>
              <td><a onclick="eliminarUsuario(${usuario.id})" href="#"><img class="img-crud" src="../images/icons8-eliminar.svg" alt=""></a></td>
          </tr>`;
      tbodyTable.insertAdjacentHTML("beforeend", usuarioHTML);
  });
});

// Obtiene una referencia al botón "Agregar" y agrega un evento de click para llamar a la función agregarUsuario
const agregar = document.getElementById("agregar");
agregar.addEventListener('click', agregarUsuario);
