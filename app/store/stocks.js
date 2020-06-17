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
	},
	add(state, item)
	{
		state.items.push(item)
	},
	remove(state, item)
	{
		var i = state.items.findIndex(x => x.id == item.id)

		Vue.delete(state.items, i)

		this.dispatch('purchases/fetch')
	}
}

export const actions =
{
	async fetch({ commit })
	{
		const { data } = await this.$axios.get('/api/stocks')

		commit('set', data)
	},
	async update({ commit }, item)
	{
		const { data } = await this.$axios.put('/api/stocks/' + item.id, item)

		commit('update', data)
	},
	async create({ commit }, item)
	{
		const { data } = await this.$axios.post('/api/stocks', item)

		commit('add', data)
	},
	async delete({ commit }, item)
	{
		await this.$axios.delete('/api/stocks/' + item.id)

		commit('remove', item)
	}
}
