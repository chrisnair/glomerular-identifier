export function initializeOpenSeadragon(containerId, options) {
    let viewer  = OpenSeadragon(Object.assign({ id: containerId }, options));

    viewer.addHandler('open', function() {
        viewer.viewport.zoomTo(options.initialZoom);
        viewer.viewport.applyConstraints();
    });
    return viewer;
 }



