export function initializeSignalR(hubUrl) {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl(hubUrl)
        .build();

    connection.start().then(() => {
        console.log("SignalR Connected.");
    }).catch(err => console.error(err.toString()));

    connection.on("ReceiveMessage", (user, message) => {
        // Logic to update the message board in real-time
    });
}
