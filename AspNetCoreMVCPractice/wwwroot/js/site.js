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
        document.getElementById('speciesId').value = parseInt(id);
        dialog.firstElementChild.innerHTML = 'Desea eliminar la especie: ' + name + '?';
        dialog.showModal();
    });
});

/**
 * Cierra el diálogo modal de eliminación
 */
function closeModal() {
    dialog.close();
}

/**
 * Maneja el envío del formulario de eliminación.
 * Realiza una petición DELETE al servidor y recarga la página si es exitosa.
 * @param {Event} event - El evento del formulario
 */
function submitDeleteForm(event) {
    event.preventDefault();
    const form = event.target.closest('form');
    const dialog = document.getElementsByTagName('dialog')[0];
    const id = document.getElementById('speciesId').value;
    
    fetch(`/Species/DeleteSpecies/${id}`, {
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
