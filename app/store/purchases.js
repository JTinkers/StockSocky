import Vue from 'vue'

export const state = () =>
({
	items: []
})

export const mutations =
{
	set(state, items)
	{
		state.items = items
	},
	update(state, item)
	{
		var i = state.items.findIndex(x => x.id == item.id)

		Vue.set(state.items, i, item)

		this.dispatch('stocks/fetch')
	},
	add(state, item)
	{
		state.items.push(item)

		this.dispatch('stocks/fetch')
	},
	remove(state, item)
	{
		var i = state.items.findIndex(x => x.id == item.id)

		Vue.delete(state.items, i)

		this.dispatch('stocks/fetch')
	}
}

export const actions =
{
	async fetch({ commit })
	{
		const { data } = await this.$axios.get('/api/purchases')

		commit('set', data)
	},
	async update({ commit }, item)
	{
		const { data } = await this.$axios.put('/api/purchases/' + item.id, item)

		commit('update', data)
	},
	async create({ commit }, item)
	{
		const { data } = await this.$axios.post('/api/purchases', item)

		commit('add', data)
	},
	async delete({ commit }, item)
	{
		await this.$axios.delete('/api/purchases/' + item.id)

		commit('remove', item)
	}
}
