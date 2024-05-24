



document.addEventListener('DOMContentLoaded', async function() {
  const nacionalidad = document.getElementById('nacionalidad');

  nacionalidad.addEventListener('input', function(event) {
    const busqueda = event.target.value.trim().toUpperCase(); 
    fetch(`https://randomuser.me/api/?results=5&nat=${busqueda}`)
      .then(response => response.json())
      .then(data => {
        const tableBody = document.getElementById('userTableBody');
        tableBody.innerHTML = ''; 

        data.results.forEach((user, index) => {
          const row = document.createElement('tr');
          row.innerHTML = `
            <td>${index + 1}</td>
            <td><img src="${user.picture.thumbnail}" alt="Imagen de ${user.name.first}"></td>
            <td>${user.name.first}</td>
            <td>${user.name.last}</td>
            <td>${user.nat}</td>
            <td><a class="details-link" href="detalle_persona${index + 1}.html"><img src="../images/icons8-detalles-48.png" alt=""></a></td>
          `;
          tableBody.appendChild(row);
        });
      })
      .catch(error => {
        console.error('Error al obtener los usuarios:', error);
      });
  });
});
