
function submitDeleteForm(event) {
    event.preventDefault();
    const form = event.target.closest('form');
    fetch(form.action, {
        method: 'DELETE',
        headers: {
            'RequestVerificationToken': form.querySelector('input[name="__RequestVerificationToken"]').value
        }
    }).then(response => {
        if (response.ok) {
            window.location.reload();
        }
    });
}
