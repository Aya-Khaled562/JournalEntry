const { window } = globalThis;
export function formatDate(dateString) {
    const date = new Date(dateString);
    const day = String(date.getDate()).padStart(2, '0');
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const year = date.getFullYear();
    return `${month}/${day}/${year}`;
}

export function isUUID(value) {
    const regex = /^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$/;
    return regex.test(value);
}
export function getIdFromUrl() {
    const path = window.location.pathname;
    const parts = path.split('/');
    const potentialId = parts[parts.length - 1];
    // Check if the last segment is a valid UUID
    return isUUID(potentialId) ? potentialId : null;
}

