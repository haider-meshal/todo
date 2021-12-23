export default async (req, res) => {
    const url = `http://${process.env.BACKEND}:80/list_todos`;

    return fetch(url)
        .then(r => r.json())
        .then(data => {
            let result = JSON.stringify(data.todos);
            return res.status(200).json(result);
        })
}
