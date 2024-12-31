export var File;
(function (File) {
    const cacheName = 'offline-cache-assets';
    File.load = function (fileName) {
        return caches.open(cacheName).then(cache => {
            return cache.match(fileName).then(response => {
                if (response) {
                    return response.text();
                }
                else {
                    return cache.add(fileName).then(() => {
                        return cache.match(fileName).then(cache_response => {
                            if (cache_response) {
                                return cache_response.text();
                            }
                        });
                    });
                }
            });
        });
    };
    File.downloadFileFromStream = async function (fileName, contentStreamReference) {
        const arrayBuffer = await contentStreamReference.arrayBuffer();
        const blob = new Blob([arrayBuffer]);
        const url = URL.createObjectURL(blob);
        const anchorElement = document.createElement('a');
        anchorElement.href = url;
        anchorElement.download = fileName ?? '';
        anchorElement.click();
        anchorElement.remove();
        URL.revokeObjectURL(url);
    };
    File.downloadFileFromBase64 = function (fileName, base64) {
        const blob = base64ToBlob(base64);
        const url = URL.createObjectURL(blob);
        const anchorElement = document.createElement('a');
        anchorElement.href = url;
        anchorElement.download = fileName ?? '';
        anchorElement.click();
        anchorElement.remove();
        URL.revokeObjectURL(url);
    };
    function base64ToBlob(base64) {
        const byteCharacters = atob(base64);
        const byteNumbers = new Array(byteCharacters.length);
        for (let i = 0; i < byteCharacters.length; i++) {
            byteNumbers[i] = byteCharacters.charCodeAt(i);
        }
        const byteArray = new Uint8Array(byteNumbers);
        return new Blob([byteArray]);
    }
})(File || (File = {}));
