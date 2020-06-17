export const actions =
{
	async nuxtClientInit({ dispatch })
	{
		await dispatch('purchases/fetch')
		await dispatch('stocks/fetch')
	}
}
