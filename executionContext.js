const html = show => `
<html>
	<head>
		<title>Test driver</title>
	</head>
	<body>
		${show ? `<p id='valueToRead'>1</p>` : ''}
		<button id="refresh" onclick='setTimeout(() => window.location.href = "/executioncontext", 10)'>Refresh</button>
	</body>
</html>
`;

const requestListener = (req, res) => {
	const cookies = req.headers['cookie'];
	const showCookie = cookies && cookies.split(';').find(c => c.trim().startsWith('show='));
	const showValue = showCookie && !!showCookie.split('=')[1] || false;

	setTimeout(() => {
		res.writeHead(200, { "Content-Type": "text/html", "Set-Cookie": `show=1` });
		res.write(html(showValue));
		return res.end();
	}, 500);
};

module.exports = {
	requestListener
}