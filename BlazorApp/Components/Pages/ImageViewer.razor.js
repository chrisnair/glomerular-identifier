export function initializeOpenSeadragon(containerId, options) {
    console.log("called")
    OpenSeadragon(Object.assign({ id: containerId }, options));
}

export function log(message) {
    return console.log(message);
}



