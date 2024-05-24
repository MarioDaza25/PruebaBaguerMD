  document.addEventListener("DOMContentLoaded",async function (){

  const nacion = document.getElementById('nacionalidad');

  nacion.addEventListener('input', function(e) {
    const datos = e.target.value.trim().toUpperCase(); 
    fetch(`https://randomuser.me/api/?results=5&nat=${datos}`)
      .then(response => response.json())
      .then(data => {
        const tabBody = document.getElementById('usertab');
        tabBody.innerHTML = ''; 
        data.results.forEach((usuario, ind) => {
          const row = document.createElement('tr');
          row.innerHTML = `
            <td>${ind + 1}</td>
            <td><img src="${usuario.picture.thumbnail}" alt=""></td>
            <td>${usuario.name.first}</td>
            <td>${usuario.name.last}</td>
            <td>${usuario.nat}</td>
            <td><a href=""><img src="../images/icons8-detalles-48.png" alt=""></a></td>
          `;
          tabBody.appendChild(row);
        });
      })
      .catch(error => {
        console.error('Error al obtener los datos:', error);
      });
  });
 })
