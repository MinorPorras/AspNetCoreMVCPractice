document.addEventListener('DOMContentLoaded', () => {
    // Aquí puedes poner el código que quieres ejecutar cuando carga la página
    console.log('La página ha cargado completamente');
    
    // Ejemplo: si estamos en la página de editar breed
    if (document.querySelector('.modifyElement')) {
        console.log('Estamos en la página de edición');
        ModifyBreed();
    }

    // Si estás en una página con el modal de eliminación
    if (document.querySelector('.deleteDialog')) {
        console.log('Podemos eliminar una especie');
        DeleteElement();
    }
});

function ModifyBreed() {
    let updateBtn = document.getElementById('updateBtn');

    updateBtn.addEventListener('click', async (e) => {
        e.preventDefault();
        const form = document.querySelector('.modifyElement');
        const id = parseInt(document.getElementById('Id').value);
        const name = document.getElementById('Name').value;
        const status = document.getElementById('Status').value === 'true';
        const speciesId = parseInt(document.getElementById('SpeciesId').value);
        const controller = document.getElementById('controller').value;

        try {
            const response = await fetch(`/${controller}/Edit/${id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                    'RequestVerificationToken': form.querySelector('input[name="__RequestVerificationToken"]').value
                },
                body: JSON.stringify({
                    id: id,
                    name: name,
                    speciesId: speciesId,
                    status: status
                })
            });

            if (response.ok) {
                window.location.href = `/${controller}/Index`;
            } else {
                const error = await response.json();
                console.error('Error al actualizar:', error.message);
                alert('Error al actualizar: ' + error.message);
            }
        } catch (error) {
            console.error('Error:', error);
            alert('Error al procesar la solicitud');
        }
    });
}

function LoadModalBtns() {
    /**
     * Selección de todos los botones que abren el modal de eliminación
     * @type {NodeListOf<Element>}
     */
    let showModalBtns = document.querySelectorAll('.showModal');

    /**
     * Referencia al diálogo modal de eliminación
     * @type {HTMLElement}
     */
    let dialog = document.getElementsByClassName('deleteDialog')[0];
    
    /**
     * Configura los event listeners para los botones de eliminación.
     * Cada botón al ser clickeado abrirá un modal de confirmación.
     */
    showModalBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            const id = btn.getAttribute('data-id');
            const name = btn.getAttribute('value');
            const pageTitle = document.querySelector('h3').textContent.trim();
            document.getElementById('Id').value = parseInt(id);
            dialog.firstElementChild.innerHTML = `Desea eliminar esta ${pageTitle.toLowerCase()}: ${name}?`;
            dialog.showModal();
        });
    });
}


// Verificar si estamos en una página con el modal de eliminación
function DeleteElement() {
    LoadModalBtns();

    /**
     * Maneja el envío del formulario de eliminación.
     * Realiza una petición DELETE al servidor y recarga la página si es exitosa.
     * @param {Event} event - El evento del formulario
     */
    function submitDeleteForm(event) {
        event.preventDefault();
        const form = event.target.closest('form');
        const id = document.getElementById('Id').value;
        const controller = document.getElementById('controller').value;
        const route = `/${controller}/Delete/${id}`
        console.log(route)
        fetch(route, {
            method: 'DELETE',
            headers: {
                'RequestVerificationToken': form.querySelector('input[name="__RequestVerificationToken"]').value
            }
        }).then(response => {
            if (response.ok) {
                closeModal();
                window.location.reload();
            } else {
                console.error('Error al eliminar la especie');
            }
        });
    }

    // Agrega el event listener al formulario de eliminación
    document.querySelector('.deleteForm').addEventListener('submit', submitDeleteForm);
}


/**
 * Cierra el diálogo modal de eliminación
 */
function closeModal() {
    let dialog = document.getElementsByClassName('deleteDialog')[0];
    dialog.close();
}

